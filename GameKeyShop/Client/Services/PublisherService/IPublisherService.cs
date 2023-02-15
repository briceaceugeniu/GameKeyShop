namespace GameKeyShop.Client.Services.PublisherService
{
    public interface IPublisherService
    {
        event Action OnChange;
        List<Publisher> Publishers { get; set; }
        Task GetPublishers();
        Task UpdatePublishers(Publisher publisher);
        Task<ServiceResponse<List<Publisher>>> DeletePublishers(int publisherId);
        Task AddPublisher(Publisher publisher);
        Publisher CreateNewPublisher();
    }
}
