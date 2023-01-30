
namespace GameKeyShop.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // empty ctor    
        }

        public DbSet<Product> Products { get; set; }
    }
}
