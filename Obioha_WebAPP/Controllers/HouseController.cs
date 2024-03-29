﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Models.ViewModel;
using Obioha_WebAPP.Services.IServices;

namespace Obioha_WebAPP.Controllers
{
    public class HouseController : Controller
    {  
        private readonly IUnitOfWorkService _UnitService;
        private IMapper _mapper;
        private APIResponse _response;
        private IWebHostEnvironment _host;
        public HouseController(IUnitOfWorkService houseService, IMapper mapper, IWebHostEnvironment host)
        {
            _UnitService = houseService;
            _mapper = mapper;
            _host = host;
        }

        public async Task<IActionResult> IndexHouse()
        {
            List<HouseDTO> List = new();

            var response = await _UnitService.HouseService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {    
                List = JsonConvert.DeserializeObject<List<HouseDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }

        public async Task<IActionResult> GetSingleHouse(int id)
        {
            HouseDTO house = new();  
            var response = await _UnitService.HouseService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                house = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(response.Result));
            }
            return View(house);
        }


        //......................Createinh..................................
        public async Task<IActionResult> CreateHouse()
        {
            HouseCreateVM houseCreateVM = new();
            return View(houseCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHouse(HouseCreateVM createDTO)
        {
            if (ModelState.IsValid)
            {

                HouseCreateVM houseCreateVM = new();
                houseCreateVM.files = createDTO.files;

                var response = await _UnitService.HouseService.CreateAsync<APIResponse>(createDTO.GetHouse);

                houseCreateVM.GetHouse = null;
                if (response != null && response.IsSuccess)
                {
                    // i converted HouseCreateDTO because i needed Id from it. i could not take id when the type was APIResponse
                    HouseCreateDTO dto = JsonConvert.DeserializeObject<HouseCreateDTO>(Convert.ToString(response.Result));

                    houseCreateVM.GetHouse = dto;

                    await GetHouseImageAsync(houseCreateVM);
                }


                TempData["success"] = "successfully Created";
                return RedirectToAction(nameof(IndexHouse), houseCreateVM);

            }
            TempData["error"] = "Fail to Create!!";
            return NotFound();
        }


        //....................Updating............................
        public async Task<IActionResult> UpdateHouse(int id)
        {

            HouseUpdateVM houseUpdateVM = new();

            var response = await _UnitService.HouseService.GetAsync<APIResponse>(id);

          if (response != null && response.IsSuccess)
            {
                houseUpdateVM.UpdateHouse = JsonConvert.DeserializeObject<HouseUpdateDTO>(Convert.ToString(response.Result));

            }
          var responseList = await _UnitService.ImageService.GetAllAsync<APIResponse>();
            if (responseList.Result != null && responseList.IsSuccess)
            {
                houseUpdateVM.UpdateImageList = null;
                
               var JsonResponce = JsonConvert.SerializeObject(responseList.Result);
                var imageList = JsonConvert.DeserializeObject<List<ImageUpdateDTO>>(Convert.ToString(JsonResponce))
                    .Where(x => x.House_Id == id).ToList();

                if (imageList.Count > 0)
                {
                    foreach (var image in imageList)
                    {   
                        var dto = _mapper.Map<ImageDTO>(image);

                        RefactorFile(dto);

                        houseUpdateVM.UpdateImageList = imageList;
                    }

                    return View(houseUpdateVM);
                }
                else
                {
                    TempData["error"] = " Image is empty!!";
                    return View(houseUpdateVM);
                   
                }
            }

            else { return View(houseUpdateVM); }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHouse(HouseUpdateVM updateDTO)
        {
            HouseUpdateVM houseUpdateVM = new HouseUpdateVM();

            if (ModelState.IsValid)
            {
                houseUpdateVM.UpdateImageList = null;
                houseUpdateVM.UpdateHouse = updateDTO.UpdateHouse;

                var response = await _UnitService.HouseService.UpdateAsync<APIResponse>(updateDTO.UpdateHouse);

                TempData["success"] = "successfully Updated!!";
                return RedirectToAction(nameof(IndexHouse));
            }
            TempData["error"] = "Fail To Update!!";
            return View(houseUpdateVM);
        }




        //....................Deleting............................
        public async Task<IActionResult> DeleteHouse(int id)
        {
            HouseVM houseVM = new();

          var jsonResult = await _UnitService.ImageService.GetAllAsync<APIResponse>();
            if (jsonResult != null && jsonResult.IsSuccess)
            {
                houseVM.imageList = null;
                houseVM.files = null;
                var imgResponse = JsonConvert.SerializeObject(jsonResult.Result);
                var imageList = JsonConvert.DeserializeObject<List<ImageDTO>>(Convert.ToString(imgResponse))
                    .Where(x => x.House_Id == id).ToList();

                foreach (var image in imageList)
                {
                    RefactorFile(image);

                    houseVM.imageList = imageList;

                }

                var response = await _UnitService.HouseService.GetAsync<APIResponse>(id);
                var jsonResult1 = JsonConvert.SerializeObject(response.Result);
                houseVM.houseDTO = JsonConvert.DeserializeObject<HouseDTO>(Convert.ToString(jsonResult1));

                return View(houseVM);
            }
            return View(houseVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteHouse(HouseVM model)
        {
            if (ModelState.IsValid)
            {
              var responseList = await _UnitService.ImageService.GetAllAsync<APIResponse>();
            
                var imageList = JsonConvert.DeserializeObject<List<ImageDTO>>(Convert.ToString(responseList.Result))
                    .Where(x => x.House_Id == model.houseDTO.Id).ToList();

                if (imageList.Count > 0)
                {
                    foreach (var image in imageList)
                    {
                        RemoveImageFromFile(image);
                    }
                }
                var response = await _UnitService.HouseService.DeleteAsync<APIResponse>(model.houseDTO.Id);

                TempData["success"] = "successfully deleted";
                return RedirectToAction(nameof(IndexHouse));
            }
            TempData["error"] = "Fail To Delete!!";
            return NotFound();
        }


        //......................other methods.................................
        private async Task<HouseCreateVM> GetHouseImageAsync(HouseCreateVM houseCreateVM)
        {
           if (houseCreateVM.files.Count > 0)
                foreach (var file in houseCreateVM.files)
                {
                    var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var upload = Path.Combine(_host.WebRootPath, @"Images");
                    var filePath = Path.Combine(upload, fileName);

                    using (var fileStreams = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    var jsonResponse = JsonConvert.SerializeObject(file);
                    var imageCreated = JsonConvert.DeserializeObject<ImageCreateDTO>(Convert.ToString(jsonResponse));
                    imageCreated.fileName = @"\Images\" + fileName;
                    houseCreateVM.ImageList.Add(imageCreated);

                  imageCreated.House_Id = houseCreateVM.GetHouse.Id;

                  var responseImage = await _UnitService.ImageService.CreateAsync<APIResponse>(imageCreated);

                }
            return houseCreateVM;

        }

       private void RefactorFile(ImageDTO image)
        {
            var fileName = Guid.NewGuid().ToString() + "_" + image;
            var Upload = Path.Combine(_host.WebRootPath, "Images");
            var filePath = Path.Combine(Upload, fileName);
        }

        private void RemoveImageFromFile(ImageDTO image)
        {
         var oldImagePath = Path.Combine(_host.WebRootPath, image.fileName.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }
    }

}
