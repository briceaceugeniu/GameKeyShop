
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
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id= 1,
                    Name = "Category 1",
                    Url = "category1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Category 2",
                    Url = "category2"
                },
                new Category
                {
                    Id = 3,
                    Name = "Category 3",
                    Url = "category3"
                }

            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Prod 1.",
                    Description = "Description Prod_ 1",
                    ImageUrl = "https://cdn.pixabay.com/photo/2012/06/19/10/32/owl-50267_960_720.jpg",
                    Price = 1.3m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Prod 2.",
                    Description = "Description Prod_ 2",
                    ImageUrl = "https://cdn.pixabay.com/photo/2022/10/29/19/21/golden-eagle-7555959_960_720.jpg",
                    Price = 3.5m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Prod 3.",
                    Description = "Description Prod_ 3",
                    ImageUrl = "https://cdn.pixabay.com/photo/2023/01/12/05/32/duck-7713310_960_720.jpg",
                    Price = 2.4m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 4,
                    Name = "Prod 4.",
                    Description = "Description Prod_ 4",
                    ImageUrl = "https://cdn.pixabay.com/photo/2023/01/26/18/09/zebra-7746719_960_720.jpg",
                    Price = 4.3m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Prod 5.",
                    Description = "Description Prod_ 5",
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/01/02/16/53/lion-1118467_960_720.jpg",
                    Price = 2.66m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Name = "Prod 6.",
                    Description = "Description Prod_ 6",
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/03/27/22/22/fox-1284512_960_720.jpg",
                    Price = 5.42m,
                    CategoryId = 3
                }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
