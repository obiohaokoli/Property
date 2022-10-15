using Obioha_VillaAPI.Models;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
        Task AddAsync(T entity);

        Task RemoveAsync(T entity);
    }
}
