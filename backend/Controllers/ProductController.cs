using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    //get all products
    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var products = await _context.Product.ToListAsync();
        return Ok(products);
    }

    //edit product
    // PUT: api/products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> EditProduct(int id, Product product)
    {
        try
        {
            var existingProduct = await _context.Product.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }   

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;

            await _context.SaveChangesAsync();

            return Ok(existingProduct);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error al editar el producto");
        }   
    }

    //delete prduct
    // DELETE: api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Product.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return Ok(product);
    }

    //create product
    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        try{
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }catch(Exception ex){
            return StatusCode(500, "Error al crear el producto");
        }
    }


}