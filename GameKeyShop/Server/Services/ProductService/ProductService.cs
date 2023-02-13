namespace GameKeyShop.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var products = await _context.Products.Include(p => p.Variants).ToListAsync();
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };
            return response;
        }


        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product? product;

            try
            {
                product = await _context.Products
                .Include(p => p.Developer)
                .Include(p => p.Publisher)
                .Include(p => p.Variants)
                .ThenInclude(v => v.PlatformType)
                .FirstOrDefaultAsync(p => p.Id == productId);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                return response;
            }
            

            if (product == null)
            {
                response.Success = false;
                response.Message = "Product not found";
            }
            else
            {
                response.Data= product;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string stringUrl)
        {
            var response = new ServiceResponse<List<Product>>();

            try
            {
                var products = await _context.Products.Where(p => p.Category != null && p.Category.Url.ToLower().Equals(stringUrl.ToLower()))
                    .Include(p => p.Variants)
                    .ToListAsync();
                response.Data = products;
            }
            catch (Exception e)
            {
                response.Success= false;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<ProductSearhResultDto>> SearchProducts(string searchText, int page)
        {
            var pageResults = 3f;

            var response = new ServiceResponse<ProductSearhResultDto>();

            try
            {
                var pageCount = Math.Ceiling((await FindProductBySearchText(searchText)).Count / pageResults);

                var products = await _context.Products
                    .Where(p => p.Name.ToLower().Contains(searchText.ToLower())
                    ||
                    p.Description.ToLower().Contains(searchText.ToLower()))
                    .Include(p => p.Variants)
                    .Skip((page - 1) * (int)pageResults)
                    .Take((int)pageResults)
                    .ToListAsync();


                response.Data = new ProductSearhResultDto
                {
                    Products = products,
                    CurrentPage = page,
                    Pages = (int)pageCount
                };

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }

        private async Task<List<Product>> FindProductBySearchText(string searchText)
        {
            return await _context.Products
                .Where(p => p.Name.ToLower().Contains(searchText.ToLower())
                ||
                p.Description.ToLower().Contains(searchText.ToLower()))
                .Include(p => p.Variants)
                .ToListAsync();
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>();

            try
            {
                var products = await _context.Products.Where(p => p.Featured)
                    .Include(p => p.Variants)
                    .ToListAsync();
                response.Data = products;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
