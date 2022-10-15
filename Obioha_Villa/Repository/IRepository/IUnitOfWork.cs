namespace Obioha_VillaAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IHouseRepository House { get; }
        ITenantRepository Tenant { get; }

        Task SaveAsync();
    }

    
}
