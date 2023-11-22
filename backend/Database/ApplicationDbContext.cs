using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración adicional de modelos, relaciones, etc.
        modelBuilder.Entity<Product>().HasKey(f => f.Id);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.U9nqgn1NvjMPLOQjDMjs2gHaG6&pid=Api&P=0&h=180",
                Name = "Papas fritas",
                Price = 10990,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
            new Product
            {
                Id = 2,
                ImageUrl = "https://tse3.mm.bing.net/th?id=OIP.oGTTlgElx79g810lUhKESQHaE7&pid=Api&P=0&h=180",
                Name = "Ensalada",
                Price = 19990,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
            new Product
            {
                Id = 3,
                ImageUrl = "https://tse4.mm.bing.net/th?id=OIP.0sKeEeaj45a1ppQqQh_kxQHaHa&pid=Api&P=0&h=180",
                Name = "Mani salado",
                Price = 29990,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
            new Product
            {
                Id = 4,
                ImageUrl = "https://picsum.photos/200/300",
                Name = "Product 4",
                Price = 39990,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            }


        );
    }
}
