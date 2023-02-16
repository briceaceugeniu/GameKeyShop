namespace GameKeyShop.Client.Services.CreditCardService
{
    public class CreditCardService : ICreditCardService
    {
        private readonly HttpClient _http;

        public CreditCardService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CreditCard> GetCreditCard()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<CreditCard>>("api/creditcard");

            return response.Data;
        }

        public async Task<CreditCard> AddOrUpdateCreditCard(CreditCard creditCard)
        {
            var response = await _http.PostAsJsonAsync("api/creditcard", creditCard);
            return response.Content.ReadFromJsonAsync<ServiceResponse<CreditCard>>().Result.Data;
        }
    }
}
