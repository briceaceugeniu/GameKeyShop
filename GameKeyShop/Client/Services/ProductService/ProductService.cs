using GameKeyShop.Shared.Models;
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
        public async Task GetProductsAsync(string? categoryUrl)
        {
            var endpointUrl = "api/product" + (categoryUrl != null ? $"/category/{categoryUrl}" : string.Empty);

            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>(endpointUrl);
            if (result is { Data: { } })
            {
                Products = result.Data;
            }

            ProductsChanged.Invoke();
        }

        public async Task<ServiceResponse<Product>?> GetProductAsync(int productId)
        {
            return await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/search/{searchText}");
            if (result is { Data: { } })
            {
                Products = result.Data;
            }

            if (Products.Count == 0)
            {
                Message = "No products found.";
            }
            ProductsChanged.Invoke();
        }
    }
}
