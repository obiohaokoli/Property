using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Services.IServices
{
    public interface IImageService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(ImageCreateDTO createDTO);
        Task<T> UpdateAsync<T>(ImageUpdateDTO updateDTO);
        Task<T> DeleteAsync<T>(int id);
    }
}
