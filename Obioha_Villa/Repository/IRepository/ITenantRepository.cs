using Obioha_VillaAPI.Models;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository.IRepository
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Task<Tenant> UpdateTenantAsync(Tenant entity);
    }
}
