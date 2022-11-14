using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Repository.IRepository;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository
{
    public class ImageRepository :Repository<Image>, IImageRepository
    {
        private readonly ApplicationDbContext _db;
        public ImageRepository( ApplicationDbContext db) : base(db )
        {
            _db = db;
        }
       
       
        public async Task<Image> UpdateImageAsync(Image entity)
        {    
            //entity.Updated_Date = DateTime.Now;
            _db.Images.Update(entity);
            return entity;  
          
        }

       
    }
}
