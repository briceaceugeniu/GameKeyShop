namespace GameKeyShop.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new();
        public async Task GetCategoriesAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/category");
            if (response is {Data: { }})
            {
                Categories = response.Data;
            }
        }
    }
}
