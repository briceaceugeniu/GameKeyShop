namespace GameKeyShop.Server.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private readonly DataContext _context;

        public PublisherService(DataContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<Publisher>>> GetPublishers()
        {
            var response = new ServiceResponse<List<Publisher>>();

            try
            {
                response.Data = await _context.Publishers.ToListAsync();
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success= false;
                response.Message = $"Could not get Publishers. Error: {e.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<List<Publisher>>> AddPublishers(Publisher publisher)
        {
            try
            {
                publisher.IsNew = publisher.Editing = false;
                _context.Publishers.Add(publisher);
                await _context.SaveChangesAsync();
                return await GetPublishers();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Publisher>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not add publisher. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<Publisher>>> UpdatePublishers(Publisher publisher)
        {
            try
            {
                var dbPublisher = await GetPublisherById(publisher.Id);

                if (dbPublisher == null)
                {
                    return new ServiceResponse<List<Publisher>>
                    {
                        Data = null,
                        Success = false,
                        Message = "Publisher could not be found"
                    };
                }

                dbPublisher.Name = publisher.Name;
                await _context.SaveChangesAsync();

                return await GetPublishers();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Publisher>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not update the publisher. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<Publisher>>> DeletePublishers(int publisherId)
        {
            try
            {
                var dbPublisher = await GetPublisherById(publisherId);

                if (dbPublisher == null)
                {
                    return new ServiceResponse<List<Publisher>>
                    {
                        Data = null,
                        Success = false,
                        Message = "Publisher could not be found"
                    };
                }

                _context.Publishers.Remove(dbPublisher);
                await _context.SaveChangesAsync();

                return await GetPublishers();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Publisher>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not delete publisher. Error: {e.Message}."
                };
            }
        }

        private async Task<Publisher?> GetPublisherById(int publisherId)
        {
            return await _context.Publishers.FirstOrDefaultAsync(p => p.Id == publisherId);
        }
    }
}
