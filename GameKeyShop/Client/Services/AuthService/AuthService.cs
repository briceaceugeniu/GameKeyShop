namespace GameKeyShop.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            var result = await _http.PostAsJsonAsync<UserLogin>("api/auth/login", request);
            var response = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

            if (result == null || response == null)
            {
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Auth error"
                };
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
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

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
