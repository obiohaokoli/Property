using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Services.IServices;

namespace Obioha_WebAPP.Controllers
{
    public class HouseController : Controller
    {   //private readonly IHouseService _UnitService;
        private readonly IUnitOfWorkService _UnitService;
        private IMapper _mapper;    
        public HouseController(IUnitOfWorkService houseService, IMapper mapper)
        {
            _UnitService = houseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexHouse()
        { 
            //expecting return type of housedto
            List<HouseDTO> List = new();

            //got json as the responset
            var response =await _UnitService.HouseService.GetAllAsync<APIResponse>();
            
            if (response != null && response.IsSuccess)
            {           //deserialise the json responset to List<HouseDTO>
             List = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }

        public async Task<IActionResult> GetSingleHouse(int id)
        {
            HouseDTO house = null;
            var response = await _UnitService.HouseService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                house = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(response.Result));
            }
            return View(house);
        }

        public async Task<IActionResult> CreateHouse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHouse(HouseCreateDTO createDTO)
        {
            var response = await _UnitService.HouseService.CreateAsync<APIResponse>(createDTO);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "successfully Created";
                return RedirectToAction(nameof(IndexHouse));
            
            }
            TempData["error"] = "Fail to Create!!";
            return View(response);
        }

        public async Task<IActionResult> UpdateHouse(int id)
        {
            var response = await _UnitService.HouseService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                HouseDTO house = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(response.Result));
                HouseUpdateDTO houseUpdate = _mapper.Map<HouseUpdateDTO>(house);
                return View(houseUpdate);
            }
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHouse(HouseUpdateDTO updateDTO)
        {
            var response = await _UnitService.HouseService.UpdateAsync<APIResponse>(updateDTO);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "successfully Updated";
                return RedirectToAction(nameof(IndexHouse));
            
            }
            TempData["error"] = "Fail To Update!!";
            return View(response);
        }

        public async Task<IActionResult> DeleteHouse(int id)
        {
            var response = await _UnitService.HouseService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                HouseDTO house = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(response.Result));

                return View(house);
            }
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteHouse(HouseDTO model)
        {
            var response = await _UnitService.HouseService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                HouseDTO house = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(response.Result));
                TempData["success"] = "successfully deleted";
                return RedirectToAction(nameof(IndexHouse));
                
            }
            TempData["error"] = "Fail To Delete!!";

            return View(response);
        }

    }
}
