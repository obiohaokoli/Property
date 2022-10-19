using Obioha_WebAPP.Services.IServices;

namespace Obioha_WebAPP.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public IHouseService HouseService { get; }
        public ITenantService TenantService { get; }

        private readonly IHttpClientFactory _httpClientFactory;
        private string UrlPart;
        public UnitOfWorkService(IHttpClientFactory factory, IConfiguration configuration)
        {

            _httpClientFactory = factory;
            UrlPart = configuration.GetValue<string>("ServiceUrl:ObiohaApi");

            HouseService = new HouseService(factory, configuration);

            TenantService = new TenantService(factory, configuration);
           
        }
    }
}
