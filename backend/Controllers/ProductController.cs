using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/productos")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/productos
    [HttpGet]
    public async Task<IActionResult> ObtenerProductos()
    {
        var productos = await _context.Product.ToListAsync();
        return Ok(productos);
    }

    // PUT: api/productos/1
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(int id, [FromBody] Product productoActualizado)
    {
        if (id != productoActualizado.Id)
        {
            return BadRequest();
        }

        _context.Entry(productoActualizado).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/productos/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        var producto = await _context.Product.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        _context.Product.Remove(producto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductoExists(int id)
    {
        return _context.Product.Any(e => e.Id == id);
    }
}
