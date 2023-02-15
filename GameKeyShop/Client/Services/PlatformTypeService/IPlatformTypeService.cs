namespace GameKeyShop.Client.Services.PlatformTypeService
{
    public interface IPlatformTypeService
    {
        event Action OnChange;
        public List<PlatformType> PlatformTypes { get; set; }
        Task GetPlatformTypes();
        Task AddPlatformType(PlatformType productType);
        Task UpdatePlatformType(PlatformType platformType);
        PlatformType CreateNewPlatformType();
    }
}
