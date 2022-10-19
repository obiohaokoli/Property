using Microsoft.AspNetCore.Mvc;
using Obioha_Utility;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Services.IServices;

namespace Obioha_WebAPP.Services
{
    
    public class TenantService : BaseService, ITenantService
    {
        private readonly IHttpClientFactory _httpClient;
        private string UrlPart;
        public TenantService(IHttpClientFactory factory, IConfiguration configuration) : base(factory)
        {
            this._httpClient = factory;
            UrlPart = configuration.GetValue<string>("ServiceUrl:ObiohaApi");
        }
        public Task<T> CreateAsync<T>(TenantCreateDTO createDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                 ApiType = SD.ApiType.POST,
                  Data = createDTO,
                   Url = UrlPart + "/api/TenantAPI"
            }); 
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = UrlPart + "/api/TenantAPI/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = UrlPart + "/api/TenantAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = UrlPart + "/api/TenantAPI/"+id
            });
        }

        public Task<T> UpdateAsync<T>(TenantUpdateDTO updateDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = updateDTO,
                Url = UrlPart + "/api/TenantAPI/"+ updateDTO.Id
            });
        }
    }
}
