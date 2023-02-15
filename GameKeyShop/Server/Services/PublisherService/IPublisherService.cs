namespace GameKeyShop.Server.Services.PublisherService
{
    public interface IPublisherService
    {
        Task<ServiceResponse<List<Publisher>>> GetPublishers();
        Task<ServiceResponse<List<Publisher>>> AddPublishers(Publisher publisher);
        Task<ServiceResponse<List<Publisher>>> UpdatePublishers(Publisher publisher);
        Task<ServiceResponse<List<Publisher>>> DeletePublishers(int publisherId);
    }
}
