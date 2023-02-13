namespace GameKeyShop.Client.Services.DeveloperService
{
    public interface IDeveloperService
    {
        event Action OnChange;
        List<Developer> Developers { get; set; }
        Task GetDevelopers();
    }
}
