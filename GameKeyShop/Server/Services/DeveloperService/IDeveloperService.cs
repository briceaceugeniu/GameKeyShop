namespace GameKeyShop.Server.Services.DeveloperService
{
    public interface IDeveloperService
    {
        Task<ServiceResponse<List<Developer>>> GetDevelopers();
        Task<ServiceResponse<List<Developer>>> AddDeveloper(Developer developer);
        Task<ServiceResponse<List<Developer>>> UpdateDeveloper(Developer developer);
        Task<ServiceResponse<List<Developer>>> DeleteDeveloper(int developerId);
    }
}
