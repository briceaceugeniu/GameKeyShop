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
            try
            {
                developer.IsNew = developer.Editing = false;
                _context.Developers.Add(developer);
                await _context.SaveChangesAsync();
                return await GetDevelopers();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Developer>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not add developer. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<Developer>>> UpdateDeveloper(Developer developer)
        {
            try
            {
                var dbDeveloper = await GetDeveloperById(developer.Id);

                if (dbDeveloper == null)
                {
                    return new ServiceResponse<List<Developer>>
                    {
                        Data = null,
                        Success = false,
                        Message = "Developer could not be found"
                    };
                }

                dbDeveloper.Name = developer.Name;
                await _context.SaveChangesAsync();
                return await GetDevelopers();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<Developer>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not update developer. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<Developer>>> DeleteDeveloper(int developerId)
        {
            throw new NotImplementedException();
        }

        private async Task<Developer?> GetDeveloperById(int developerId)
        {
            return await _context.Developers.FirstOrDefaultAsync(d => d.Id == developerId);
        }
    }
}
