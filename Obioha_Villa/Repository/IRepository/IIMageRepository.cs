using Obioha_VillaAPI.Models;
using System.Linq.Expressions;

namespace Obioha_VillaAPI.Repository.IRepository
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<Image> UpdateImageAsync(Image entity);
    }
}
