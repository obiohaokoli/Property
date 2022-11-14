namespace Obioha_WebAPP.Services.IServices
{
    public interface IUnitOfWorkService
    {
        IHouseService HouseService { get; }
        ITenantService TenantService { get; }
        IImageService ImageService { get; }
    }
}
