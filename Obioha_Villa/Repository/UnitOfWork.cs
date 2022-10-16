using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Repository.IRepository;

namespace Obioha_VillaAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IHouseRepository House { get; private set; }
        public ITenantRepository Tenant { get; private set; }

        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            House = new HouseRepository(db);
            Tenant = new TenantRepository(db);
         }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();

        }
    }

   
}
