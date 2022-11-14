using Microsoft.AspNetCore.Mvc;
using Obioha_Utility;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Services.IServices;

namespace Obioha_WebAPP.Services
{
    
    public class ImageService : BaseService, IImageService
    {
        private readonly IHttpClientFactory _httpClient;
        private string UrlPart;
        public ImageService(IHttpClientFactory factory, IConfiguration configuration) : base(factory)
        {
            this._httpClient = factory;
            UrlPart = configuration.GetValue<string>("ServiceUrl:ObiohaApi");
        }
        public Task<T> CreateAsync<T>(ImageCreateDTO createDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                 ApiType = SD.ApiType.POST,
                  Data = createDTO,
                   Url = UrlPart + "/api/ImageAPI"
            }); 
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = UrlPart + "/api/ImageAPI/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = UrlPart + "/api/ImageAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = UrlPart + "/api/ImageAPI/"+id
            });
        }

        public Task<T> UpdateAsync<T>(ImageUpdateDTO updateDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = updateDTO,
                Url = UrlPart + "/api/ImageAPI/"+ updateDTO.Image_Id
            });
        }
    }
}
