using System.Security.Cryptography;

namespace GameKeyShop.Client.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private readonly HttpClient _http;

        public PublisherService(HttpClient http)
        {
            _http = http;
        }

        public event Action OnChange;
        public List<Publisher> Publishers { get; set; } = new();


        public async Task GetPublishers()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Publisher>>>("api/publisher/admin");

            if (response is {Data: {}})
            {
                Publishers = response.Data;
            }
        }

        public async Task UpdatePublishers(Publisher publisher)
        {
            var response = await _http.PutAsJsonAsync("api/publisher/admin", publisher);
            Publishers = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Publisher>>>()).Data;

            OnChange.Invoke();
        }

        public async Task<ServiceResponse<List<Publisher>>> DeletePublishers(int publisherId)
        {
            var response = await _http.DeleteAsync($"api/publisher/admin/{publisherId}").ConfigureAwait(false);
            var content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Publisher>>>();

            if (content is {Success: true, Data: { }})
            {
                Publishers = content.Data;
                OnChange.Invoke();

                return content;
            }

            return new ServiceResponse<List<Publisher>>{ Success = false, Message = content != null ? content.Message : "Mysterious error." };
        }

        public async Task AddPublisher(Publisher publisher)
        {
            var response = await _http.PostAsJsonAsync("api/publisher/admin", publisher);
            Publishers = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Publisher>>>()).Data;

            OnChange.Invoke();
        }

        public Publisher CreateNewPublisher()
        {
            var newPublisher = new Publisher {IsNew = true, Editing = true};
            Publishers.Add(newPublisher);

            OnChange.Invoke();
            return newPublisher;
        }
    }
}
