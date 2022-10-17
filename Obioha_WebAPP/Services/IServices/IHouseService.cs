using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Services.IServices
{
    public interface IHouseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(HouseCreateDTO createDTO);
        Task<T> UpdateAsync<T>(HouseUpdateDTO updateDTO);
        Task<T> DeleteAsync<T>(int id);
    }
}
