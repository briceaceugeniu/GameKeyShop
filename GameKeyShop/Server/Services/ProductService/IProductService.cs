namespace GameKeyShop.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string stringUrl);
        Task<ServiceResponse<ProductSearhResultDto>> SearchProducts(string searchText, int page);
        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();

    }
}
