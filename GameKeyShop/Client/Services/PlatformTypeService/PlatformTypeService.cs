namespace GameKeyShop.Client.Services.PlatformTypeService
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly HttpClient _http;

        public PlatformTypeService(HttpClient http)
        {
            _http = http;
        }

        public event Action OnChange;
        public List<PlatformType>? PlatformTypes { get; set; } = new();

        public async Task GetPlatformTypes()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<PlatformType>>>("api/platformtype");
            PlatformTypes = result?.Data;
        }

        public async Task AddPlatformType(PlatformType productType)
        {
            var response = await _http.PostAsJsonAsync("api/platformtype", productType);
            PlatformTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<PlatformType>>>()).Data;

            OnChange.Invoke();
        }

        public async Task UpdatePlatformType(PlatformType platformType)
        {
            var response = await _http.PutAsJsonAsync("api/platformtype", platformType);
            PlatformTypes = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<PlatformType>>>()).Data;

            OnChange.Invoke();
        }

        public PlatformType CreateNewPlatformType()
        {
            var newPlatformType = new PlatformType {IsNew = true, Editing = true};
            PlatformTypes.Add(newPlatformType);

            OnChange.Invoke();
            
            return newPlatformType;
        }
    }
}
