using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository
{
    public class HouseRepository :Repository<House>, IHouseRepository
    {
        private readonly ApplicationDbContext _db;
        public HouseRepository( ApplicationDbContext db) : base(db )
        {
            _db = db;
        }
       
       
        public async Task<House> UpdateHouseAsync(House entity)
        {    
            entity.Updated_Date = DateTime.Now;
            _db.Houses.Update(entity);
            return entity;  
          
        }
     
      

       
    }
}
