using static System.Net.WebRequestMethods;

namespace GameKeyShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public event Action ProductsChanged;
        public string Message { get; set; } = "Loading products...";
        public List<Product> Products { get; set; } = new();
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public async Task GetProductsAsync(string? categoryUrl)
        {
            var endpointUrl = "api/product" + (categoryUrl != null ? $"/category/{categoryUrl}" : "/featured");

            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>(endpointUrl);
            if (result is { Data: { } })
            {
                Products = result.Data;
            }

            CurrentPage = 1;
            PageCount = 0;

            if(Products.Count == 0)
            {
                Message = "No products found";
            }

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>?> GetProductAsync(int productId)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;

            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductSearhResultDto>>($"api/product/search/{searchText}/{page}");
            if (result is { Data: { } })
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }

            if (Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductsChanged.Invoke();
        }
    }
}
