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
        public List<Product> AdminProducts { get; set; } = new();
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public async Task GetAdminProducts()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/admin");
            AdminProducts = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminProducts.Count == 0)
                Message = "No products found.";
        }

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

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await _http.PostAsJsonAsync("api/product", product);
            var newProduct = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Product>>()).Data;
            return newProduct;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            Console.WriteLine("g2");
            var result = await _http.PutAsJsonAsync($"api/product", product);
            Console.WriteLine($"g3: {result}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>();
            Console.WriteLine("g4");
            return content.Data;
        }

        public async Task DeleteProduct(Product product)
        {
            await _http.DeleteAsync($"api/product/{product.Id}");
        }
    }
}
