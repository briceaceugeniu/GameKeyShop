namespace GameKeyShop.Server.Services.DeveloperService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly DataContext _context;

        public DeveloperService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Developer>>> GetDevelopers()
        {
            var response = new ServiceResponse<List<Developer>>();

            try
            {
                response.Data = await _context.Developers.ToListAsync();
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Success = false;
                response.Message = $"Could not get developers types. Error: {e.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<List<Developer>>> AddDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Developer>>> UpdateDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Developer>>> DeleteDeveloper(int developerId)
        {
            throw new NotImplementedException();
        }
    }
}
