using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obioha_WebAPP.Models.DTO;

namespace Obioha_WebAPP.Models.ViewModel
{
    public class TenantUpdateVM
    {
        public TenantUpdateVM()
        {
            GetTenant = new TenantUpdateDTO();

        }
        public TenantUpdateDTO GetTenant { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> tenantList { get; set; } 

    }
}
