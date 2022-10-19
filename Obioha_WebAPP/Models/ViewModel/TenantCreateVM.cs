using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Models.ViewModel
{
    public class TenantCreateVM
    {
        public TenantCreateVM()
        {
            GetTenantCreateDTO = new TenantCreateDTO();
           
        }
        public TenantCreateDTO GetTenantCreateDTO { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TenantLocations { get; set; }
    }
}
