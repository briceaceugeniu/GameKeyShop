namespace GameKeyShop.Client.Services.DeveloperService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly HttpClient _http;

        public DeveloperService(HttpClient http)
        {
            _http = http;
        }

        public event Action OnChange;
        public List<Developer> Developers { get; set; } = new();
        public async Task GetDevelopers()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Developer>>>("api/developer/admin");

            if (response is {Data: { }})
            {
                Developers = response.Data;
            }
        }

        public async Task AddDeveloper(Developer developer)
        {
            var response = await _http.PostAsJsonAsync("api/developer/admin", developer);
            Developers = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Developer>>>()).Data;

            OnChange.Invoke();
        }

        public async Task UpdateDeveloper(Developer developer)
        {
            var response = await _http.PutAsJsonAsync("api/developer/admin", developer);
            Developers = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Developer>>>()).Data;

            OnChange.Invoke();
        }

        public Developer CreateNewDeveloper()
        {
            var newDeveloper = new Developer {IsNew = true, Editing = true};
            Developers.Add(newDeveloper);

            OnChange.Invoke();
            return newDeveloper;
        }
    }
}
