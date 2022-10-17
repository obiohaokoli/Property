using Obioha_WebAPP.Models;

namespace Obioha_WebAPP.Services.IServices
{
    public interface IBaseService
    {
        APIResponse _response { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
