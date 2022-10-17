using Obioha_Utility;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Services.IServices;

namespace Obioha_WebAPP.Services
{
    public class HouseService : BaseService, IHouseService
    {   private IHttpClientFactory _httpClientFactory;
        private string UriPart;
        public HouseService(IHttpClientFactory httpClientFactory, IConfiguration configuration)  : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            UriPart = configuration.GetValue<string>("ServiceUrl:ObiohaApi");

        }
        public Task<T> CreateAsync<T>(HouseCreateDTO createDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = createDTO,
                Url = UriPart + "/api/VillaAPI"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = UriPart + "/api/VillaAPI/"+id

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = UriPart + "/api/VillaAPI/"+id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = UriPart + "/api/VillaAPI"

            });
        }

        public Task<T> UpdateAsync<T>(HouseUpdateDTO updateDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = updateDTO,
                Url = UriPart + "/api/VillaAPI/"+updateDTO.Id

            });
        }
    }
}
