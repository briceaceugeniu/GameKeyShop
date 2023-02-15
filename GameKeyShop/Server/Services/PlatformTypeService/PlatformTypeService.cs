using System.Runtime.Versioning;

namespace GameKeyShop.Server.Services.PlatformTypeService
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly DataContext _context;

        public PlatformTypeService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<PlatformType>>> GetPlatformTypes()
        {
            var response = new ServiceResponse<List<PlatformType>>();
            try
            {
                response.Data = await _context.PlatformTypes.ToListAsync();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Data = null;
                response.Message = $"Could not get platform types. Error: {e.Message}";
            }

            return response;
        }

        public async Task<ServiceResponse<List<PlatformType>>> AddPlatformType(PlatformType platformType)
        {
            try
            {
                platformType.IsNew = platformType.Editing = false;
                _context.PlatformTypes.Add(platformType);
                await _context.SaveChangesAsync();
                return await GetPlatformTypes();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<PlatformType>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not add platform type. Error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<List<PlatformType>>> UpdatePlatformType(PlatformType platformType)
        {
            try
            {
                var dbPlatformType = await GetPlatformTypeById(platformType.Id);

                if (dbPlatformType == null)
                {
                    return new ServiceResponse<List<PlatformType>>
                    {
                        Data = null,
                        Success = false,
                        Message = $"Platform Type could not be found."
                    };
                }

                dbPlatformType.Name = platformType.Name;

                await _context.SaveChangesAsync();
                return await GetPlatformTypes();
            }
            catch (Exception e)
            {
                return new ServiceResponse<List<PlatformType>>
                {
                    Data = null,
                    Success = false,
                    Message = $"Could not update platform type. Error: {e.Message}"
                };
            }
        }

        private async Task<PlatformType?> GetPlatformTypeById(int id)
        {
            return await _context.PlatformTypes.FirstOrDefaultAsync(pt => pt.Id == id);
        }
    }
}
