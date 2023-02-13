namespace GameKeyShop.Client.Services.DeveloperService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly HttpClient _http;

        public DeveloperService(HttpClient http)
        {
            _http = http;
        }

        public event Action? OnChange;
        public List<Developer> Developers { get; set; }
        public async Task GetDevelopers()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Developer>>>("api/developer/admin");

            if (response is {Data: { }})
            {
                Developers = response.Data;
            }
        }
    }
}
