namespace GameKeyShop.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        public string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        List<Product> Products { get; set; }
        List<Product> AdminProducts { get; set; }
        Task GetAdminProducts();
        Task GetProductsAsync(string? categoryUrl = null);
        Task<ServiceResponse<Product>?> GetProductAsync(int productId);
        Task SearchProducts(string searchText, int page);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
