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
                    PlatformTypeId = 4,
                    Price = 44.29m,
                    OriginalPrice = 46.99m
                },
                new ProductVariant
                {
                    ProductId = 3,
                    PlatformTypeId = 2,
                    Price = 11.99m,
                    OriginalPrice = 12.99m
                },
                new ProductVariant
                {
                    ProductId = 4,
                    PlatformTypeId = 1,
                    Price = 25.99m,
                    OriginalPrice = 33.99m
                },
                new ProductVariant
                {
                    ProductId = 5,
                    PlatformTypeId = 3,
                    Price = 34.99m,
                    OriginalPrice = 44.99m
                },
                new ProductVariant
                {
                    ProductId = 6,
                    PlatformTypeId = 4,
                    Price = 21.99m,
                    OriginalPrice = 23.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    PlatformTypeId = 4,
                    Price = 33.99m,
                    OriginalPrice = 56.99m
                },
                new ProductVariant
                {
                    ProductId = 7,
                    PlatformTypeId = 1,
                    Price = 30.99m,
                    OriginalPrice = 32.99m
                },
                new ProductVariant
                {
                    ProductId = 8,
                    PlatformTypeId = 2,
                    Price = 65.99m,
                    OriginalPrice = 66.99m
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
                    Description = "One of the most celebrated real-time strategy franchises is getting a long-awaited new installment! " +
                                  "Become the key player in events that shaped human history with Relic Entertainment, " +
                                  "World’s Edge and Xbox Game Studios’ latest release - Age of Empires IV. ",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/s/s/ss_20d475d96c3a3dcb720103ce79e22d41df1aa8e0.1920x1080-min_26_.jpg",
                    CategoryId = 8
                },
                new Product
                {
                    Id = 2,
                    Name = "HOGWARTS LEGACY",
                    Description = "Hogwarts Legacy is an open-world action RPG set in the world first introduced in the Harry Potter books. " +
                                  "Embark on a journey through familiar and new locations as you explore and discover magical beasts, " +
                                  "customize your character and craft potions, master spell casting, upgrade talents and become the wizard you want to be.",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/c/u/cupheaddeliciouslast-1640043161876_3__2.jpg",
                    Featured = true,
                    CategoryId = 5
                },
                new Product
                {
                    Id = 3,
                    Name = "FIFA 23",
                    Description = "EA SPORTS\u2122 FIFA 23 brings The World’s Game to the pitch, with HyperMotion2 Technology that delivers even more game-play realism, " +
                                  "both the men’s and women’s FIFA World Cup\u2122 coming to the game later in the the season, the addition of women’s club teams, " +
                                  "cross-play features, and more. Experience unrivaled authenticity with over 19,000 players, 700+ teams, 100 stadiums, and over 30 leagues in FIFA 23.",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/a/a/aaaa_5.jpg",
                    CategoryId = 6
                },
                new Product
                {
                    Id = 4,
                    Name = "ELDEN RING",
                    Description = "Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between. " +
                                  "In the Lands Between ruled by Queen Marika the Eternal, the Elden Ring, the source of the Erdtree, has been shattered.",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/5/d/5de6658946177c5f23698932_24_.jpg",
                    Featured= true,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "THE SETTLERS: NEW ALLIES",
                    Description = "The Settlers combines a fresh take on the popular game-play mechanics of the series with a new spin. " +
                                  "It offers a deep infrastructure and economy game-play, used to create and employ armies, to ultimately defeat opponents.",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/s/a/sadasd.jpg",
                    CategoryId = 8
                },
                new Product
                {
                    Id = 6,
                    Name = "ASSASSIN'S CREED UNITY",
                    Description = "In Assassin's Creed Unity you will become the ultimate assassin and change the course of history forever." +
                                  "Experience the French Revolution first hand. You'll need to hone your skills and equipment to survive the chaos!",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/h/e/hero_11_.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "HORIZON FORBIDDEN WEST",
                    Description = "Explore distant lands, fight bigger and more awe-inspiring machines, and encounter astonishing new tribes as you return " +
                                  "to the far-future, post-apocalyptic world of Horizon.",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/h/e/header_10_15__1.jpg",
                    Featured= true,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 8,
                    Name = "HE LAST OF US PART I",
                    Description = "Experience the emotional storytelling and unforgettable characters in The Last of Us, winner of over 200 Game of the Year awards, " +
                                  "now rebuilt from the ground up for the PlayStation®5 console.",
                    ImageUrl = "https://cdn.cdkeys.com/700x700/media/catalog/product/r/o/roadwarden_5_.jpg",
                    CategoryId = 7
                }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PlatformType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
