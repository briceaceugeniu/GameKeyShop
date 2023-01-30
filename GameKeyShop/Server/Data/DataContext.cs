
namespace GameKeyShop.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // empty ctor    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Prod 1",
                    Description = "Description Prod 1",
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/06/19/10/32/owl-50267_960_720.jpg",
                    Price = 1.3m
                },
                new Product
                {
                    Id = 2,
                    Name = "Prod 2",
                    Description = "Description Prod 2",
                    ImageUrl = "https://cdn.pixabay.com/photo/2022/10/29/19/21/golden-eagle-7555959_960_720.jpg",
                    Price = 3.5m
                },
                new Product
                {
                    Id = 3,
                    Name = "Prod 3",
                    Description = "Description Prod 3",
                    ImageUrl = "https://cdn.pixabay.com/photo/2023/01/12/05/32/duck-7713310_960_720.jpg",
                    Price = 2.4m
                }
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}
