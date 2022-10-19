using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Services.IServices
{
    public interface ITenantService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(TenantCreateDTO createDTO);
        Task<T> UpdateAsync<T>(TenantUpdateDTO updateDTO);
        Task<T> DeleteAsync<T>(int id);
    }
}
