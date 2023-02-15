namespace GameKeyShop.Client.Services.DeveloperService
{
    public interface IDeveloperService
    {
        event Action OnChange;
        List<Developer> Developers { get; set; }
        Task GetDevelopers();
        Task AddDeveloper(Developer developer);
        Task UpdateDeveloper(Developer developer);
        Developer CreateNewDeveloper();
    }
}
