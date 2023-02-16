namespace GameKeyShop.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var products = await _context.Products
                .Where(p => p.Visible && !p.Deleted)
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted)).ToListAsync();
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetAdminProductsAsync()
        {
            var products = await _context.Products
                //.Where(p => p.Visible)
                .Include(p => p.Variants.Where(v => !v.Deleted))
                .ThenInclude(v => v.PlatformType)
                .ToListAsync();
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
                if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
                {
                    product = await _context.Products
                        .Include(p => p.Developer)
                        .Include(p => p.Publisher)
                        .Include(p => p.Variants.Where(v => !v.Deleted))
                        .ThenInclude(v => v.PlatformType)
                        .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted);
                }
                else
                {
                    product = await _context.Products
                        .Include(p => p.Developer)
                        .Include(p => p.Publisher)
                        .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                        .ThenInclude(v => v.PlatformType)
                        .FirstOrDefaultAsync(p => p.Id == productId && p.Visible && !p.Deleted);
                }
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
                var products = await _context.Products
                    .Where(p => p.Category != null && p.Category.Url.ToLower().Equals(stringUrl.ToLower()) && p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
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
                    p.Description.ToLower().Contains(searchText.ToLower()) && 
                    p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
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
                            || p.Description.ToLower().Contains(searchText.ToLower()) &&
                    p.Visible && !p.Deleted)
                .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
                .ToListAsync();
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>();

            try
            {
                var products = await _context.Products.Where(p => p.Featured && p.Visible && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visible && !v.Deleted))
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

        public async Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            foreach (var variant in product.Variants)
            {
                variant.PlatformType = null;
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (dbProduct == null)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Visible = product.Visible;
            dbProduct.Featured = product.Featured;

            foreach (var variant in product.Variants)
            {
                var dbVariant = await _context.ProductVariants
                    .SingleOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                                               v.PlatformTypeId == variant.PlatformTypeId);
                if (dbVariant == null)
                {
                    variant.PlatformType = null;
                    _context.ProductVariants.Add(variant);
                }
                else
                {
                    dbVariant.PlatformTypeId = variant.PlatformTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.Visible = variant.Visible;
                    dbVariant.Deleted = variant.Deleted;
                }
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<Product> { Data = product };
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Deleted = true;
            dbProduct.Visible = false;

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}
