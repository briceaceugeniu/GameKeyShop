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
            modelBuilder.Entity<ProductVariant>()
                .HasKey(x => new { x.ProductId, x.PlatformTypeId });

            modelBuilder.Entity<PlatformType>().HasData(
                new PlatformType { Id = 1, Name = "PC"},
                new PlatformType { Id = 2, Name = "PSN"},
                new PlatformType { Id = 3, Name = "Nintendo"},
                new PlatformType { Id = 4, Name = "Xbox"}
            );

            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant
                {
                    ProductId = 1,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                },
                new ProductVariant
                {
                    ProductId = 2,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                },
                new ProductVariant
                {
                    ProductId = 6,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    PlatformTypeId = 1,
                    Price = 14.99m,
                    OriginalPrice = 18.99m
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id= 1,
                    Name = "Action",
                    Url = "action"
                },
                new Category
                {
                    Id = 2,
                    Name = "Adventure",
                    Url = "adventure"
                },
                new Category
                {
                    Id = 3,
                    Name = "RPG",
                    Url = "rpg"
                },
                new Category
                {
                    Id = 4,
                    Name = "Fantasy",
                    Url = "fantasy"
                },
                new Category
                {
                    Id = 5,
                    Name = "Open World",
                    Url = "open-world"
                },
                new Category
                {
                    Id = 6,
                    Name = "Sports",
                    Url = "sports"
                },
                new Category
                {
                    Id = 7,
                    Name = "Horror",
                    Url = "horror"
                },
                new Category
                {
                    Id = 8,
                    Name = "Strategy",
                    Url = "strategy"
                }

            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Age of Empires 4",
                    Description = "One of the most celebrated real-time strategy franchises is getting a long-awaited new installment! Become the key player in events that shaped human history with Relic Entertainment, World’s Edge and Xbox Game Studios’ latest release - Age of Empires IV. ",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/s/s/ss_20d475d96c3a3dcb720103ce79e22d41df1aa8e0.1920x1080-min_26_.jpg",
                    CategoryId = 8
                },
                new Product
                {
                    Id = 2,
                    Name = "HOGWARTS LEGACY",
                    Description = "Hogwarts Legacy is an open-world action RPG set in the world first introduced in the Harry Potter books. Embark on a journey through familiar and new locations as you explore and discover magical beasts, customize your character and craft potions, master spell casting, upgrade talents and become the wizard you want to be.",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/c/u/cupheaddeliciouslast-1640043161876_3__2.jpg",
                    CategoryId = 5
                },
                new Product
                {
                    Id = 3,
                    Name = "Prod 3.",
                    Description = "Description Prod_ 3",
                    ImageUrl = "https://cdn.pixabay.com/photo/2023/01/12/05/32/duck-7713310_960_720.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 4,
                    Name = "Prod 4.",
                    Description = "Description Prod_ 4",
                    ImageUrl = "https://cdn.pixabay.com/photo/2023/01/26/18/09/zebra-7746719_960_720.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Prod 5.",
                    Description = "Description Prod_ 5",
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/01/02/16/53/lion-1118467_960_720.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Name = "Prod 6.",
                    Description = "Description Prod_ 6",
                    ImageUrl = "https://cdn.pixabay.com/photo/2016/03/27/22/22/fox-1284512_960_720.jpg",
                    CategoryId = 3
                }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PlatformType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
