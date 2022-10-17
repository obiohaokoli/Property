using Newtonsoft.Json;
using Obioha_Utility;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Services.IServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Obioha_WebAPP.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse _response { get; set; }

        IHttpClientFactory _httpClient;
        public BaseService(IHttpClientFactory  httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _response = new();
        }
        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var Client = _httpClient.CreateClient("obioha_Properties");

                //to configure the message we need the HttpRequestMessage
                HttpRequestMessage RequestMessage = new HttpRequestMessage();
                RequestMessage.Headers.Add("Accept", "application/json");
                RequestMessage.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {   // the object in apiRequest.Data is serialise to json
                    RequestMessage.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        RequestMessage.Method = HttpMethod.Post;
                        break;

                    case SD.ApiType.PUT:
                        RequestMessage.Method = HttpMethod.Put;
                        break;

                    case SD.ApiType.DELETE:
                        RequestMessage.Method = HttpMethod.Delete;
                        break;

                    default:
                        RequestMessage.Method = HttpMethod.Get;
                        break;
                }

                //define httpResponseMessage
                HttpResponseMessage HttpResponse = null;
                HttpResponse = await Client.SendAsync(RequestMessage);

                //serialise http content to a string
                var ResponseMessage = await HttpResponse.Content.ReadAsStringAsync();
                var Response = JsonConvert.DeserializeObject<T>(ResponseMessage);
                return Response;
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
                _response.IsSuccess = false;

                //need to serialise it because it  need to be return in a type T but the result is not in type T. so when serialised then deserialise have method that take a certain type as deserialiseObject<TYPE>()
                var result = JsonConvert.SerializeObject(_response);
                var ApiResponse = JsonConvert.DeserializeObject<T>(result);
                return ApiResponse;
            }
        }
    }
}
