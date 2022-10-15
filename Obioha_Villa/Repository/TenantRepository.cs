using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository
{
    public class TenantRepository :Repository<Tenant>, ITenantRepository
    {
        private readonly ApplicationDbContext _db;
        public TenantRepository( ApplicationDbContext db) : base(db )
        {
            _db = db;
        }
       
       
        public async Task<Tenant> UpdateTenantAsync(Tenant entity)
        {    
            //entity.Updated_Date = DateTime.Now;
            _db.Tenants.Update(entity);
            return entity;  
          
        }

       
    }
}
