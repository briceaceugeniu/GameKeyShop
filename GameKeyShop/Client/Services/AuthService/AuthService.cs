namespace GameKeyShop.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await _http.PostAsJsonAsync<UserRegister>("api/auth/register", request);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();

            if (result == null || response == null)
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Network Error"
                };
            }
            return response;
        }
    }
}
