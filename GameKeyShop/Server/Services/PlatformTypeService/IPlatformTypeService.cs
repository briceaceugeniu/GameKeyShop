namespace GameKeyShop.Server.Services.PlatformTypeService
{
    public interface IPlatformTypeService
    {
        Task<ServiceResponse<List<PlatformType>>> GetPlatformTypes();
        Task<ServiceResponse<List<PlatformType>>> AddPlatformType(PlatformType platformType);
        Task<ServiceResponse<List<PlatformType>>> UpdatePlatformType(PlatformType platformType);
    }
}
