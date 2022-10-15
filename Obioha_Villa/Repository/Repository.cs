using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository
{
    public class Repository<T> : IRepository<T> where T :class    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db )
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            //we use iQueryable because it causes differs execution
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();

        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

        }
        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);

        }




    }

}

