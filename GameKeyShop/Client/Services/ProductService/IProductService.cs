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
        Task GetProductsAsync(string? categoryUrl = null);
        Task<ServiceResponse<Product>?> GetProductAsync(int productId);
        Task SearchProducts(string searchText, int page);
    }
}
