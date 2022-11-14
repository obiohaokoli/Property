using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Models.ViewModel;
using Obioha_WebAPP.Services.IServices;
using System.Net;


namespace Obioha_WebAPP.Controllers
{
    public class TenantController : Controller
    {
        private readonly IUnitOfWorkService _UnitService;
            private IMapper _mapper;
       
        public TenantController( IUnitOfWorkService unitOf, IMapper mapper)
        {
            _UnitService = unitOf;
            _mapper = mapper;
           
        }
        public async Task<IActionResult> IndexTenant()
        {
            List<TenantDTO> List = null;
          var response = await _UnitService.TenantService.GetAllAsync<APIResponse>();
            if(response != null && response.IsSuccess)
            {
               //var JResponse = JsonConvert.SerializeObject(response.Result);
                 List = JsonConvert.DeserializeObject<List<TenantDTO>>(Convert.ToString(response.Result));

            }
            return View(List);
        }

        public async Task<IActionResult> GetSingle(int id)
        {
            TenantDTO Tenant = null;
            var response = await _UnitService.TenantService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                Tenant = JsonConvert.DeserializeObject<TenantDTO>(Convert.ToString(response.Result));
            }
            return View(Tenant);
        }
        

        [HttpGet]
        public async Task<IActionResult> CreateTenant()
        {
             return View(await TenantDDServiceAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTenant(TenantCreateVM createDTO)
        {
            if (ModelState.IsValid)
            {
        var response = await _UnitService.TenantService.CreateAsync<APIResponse>(createDTO.GetTenantCreateDTO);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "successfully Created";
                    response.IsSuccess = true;
                    response.StatusCode = HttpStatusCode.Created;
                    return RedirectToAction(nameof(IndexTenant));

                }
                TempData["error"] = "Fail to Create!!";
                await TenantDDServiceAsync();
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadGateway;
                ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());

            }
          
            return  BadRequest();
        }

        public async Task<IActionResult> UpdateTenant(int id)
        {

            TenantUpdateVM tenantUpdateVM = new TenantUpdateVM();
           var response = await _UnitService.TenantService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                TenantUpdateDTO Tenant = JsonConvert.DeserializeObject<TenantUpdateDTO>(Convert.ToString(response.Result));
             
                tenantUpdateVM.GetTenant = Tenant;
            }

           var HouseForDD = await _UnitService.HouseService.GetAllAsync<APIResponse>();
            if (HouseForDD != null && HouseForDD.IsSuccess)
            {
                List<HouseDTO> houseListForDD = JsonConvert.DeserializeObject<List<HouseDTO>>
                     (Convert.ToString(HouseForDD.Result));
                tenantUpdateVM.tenantList = houseListForDD
                     .Select(i => new SelectListItem
                     {
                         Text = i.Name,
                         Value = i.Id.ToString()
                     });
            }
          return View(tenantUpdateVM);
            

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTenant(TenantUpdateVM updateDTO)
        {
            if (ModelState.IsValid)
            {
              var response = await _UnitService.TenantService.UpdateAsync<APIResponse>(updateDTO.GetTenant);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "successfully Updated";
                    return RedirectToAction(nameof(IndexTenant));
                }
                else
                {       
                    if(response.ErrorMessages.Count > 0)
                    {
                        TempData["error"] = "Fail To Update!!";
                        response.IsSuccess = false;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        ModelState.AddModelError("ErrorMessages",response.ErrorMessages.FirstOrDefault());
                    }
                   
                }
             
            }
            TempData["error"] = "Fail To Update!!";
            return NotFound();  
      }

        public async Task<IActionResult> DeleteTenant(int id)
        {
            var response = await _UnitService.TenantService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                TenantDTO tenant = JsonConvert.DeserializeObject<TenantDTO>(Convert.ToString(response.Result));

                return View(tenant);
            }
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTenant(TenantDTO model)
        {
            var response = await _UnitService.TenantService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                TenantDTO house = JsonConvert.DeserializeObject<TenantDTO>(Convert.ToString(response.Result));
                TempData["success"] = "successfully deleted";
                return RedirectToAction(nameof(IndexTenant));

            }
            TempData["error"] = "Fail To Delete!!";

            return View(response);
        }

        public async Task<TenantCreateVM>  TenantDDServiceAsync()
        {
             var response = await _UnitService.HouseService.GetAllAsync<APIResponse>();        
            
                List<HouseDTO> houseDTO = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(response.Result));

                TenantCreateVM tenantCreateVM = new();

                tenantCreateVM.TenantLocations = new List<SelectListItem>();
                tenantCreateVM.TenantLocations = houseDTO.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                
            return tenantCreateVM;

        }
       
       
    }
}
