using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Obioha_WebAPP.Models;
using Obioha_WebAPP.Models.DTO;
using Obioha_WebAPP.Models.ViewModel;
using Obioha_WebAPP.Services.IServices;

namespace Obioha_WebAPP.Controllers
{
    public class ImageController : Controller
    {  //private readonly IHouseService _UnitService;
        private readonly IUnitOfWorkService _UnitService;
        private IMapper _mapper;
        private APIResponse _response;
        private IWebHostEnvironment _host;
        public ImageController(IUnitOfWorkService houseService, IMapper mapper, IWebHostEnvironment host)
        {
            _UnitService = houseService;
            _mapper = mapper;
            _host = host;
        }

        public async Task<IActionResult> ImageIndex()
        {
            //expecting return type of housedto
            List<ImageDTO>? List = new();

            //got json as the responset
            var response = await _UnitService.HouseService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {           //deserialise the json responset to List<HouseDTO>
                List = JsonConvert.DeserializeObject<List<ImageDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }

        public async Task<IActionResult> GetSingle(int id)
        {    
            ImageDTO image = null;
            var response = await _UnitService.ImageService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                image = JsonConvert.DeserializeObject<ImageDTO>(Convert.ToString(response.Result));
            }
            return View(image);
        }

        public async Task<IActionResult> CreateImage()
        {
            ImageCreateVM CreateVM = new ImageCreateVM();
            return View(CreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateImage(int Id,ImageCreateVM CreateVM)
        {       
                 CreateVM.ImageList.House_Id = Id;
            
                 if (CreateVM.file != null)
                
                {
                    CreateVM.ImageList.fileName = CreateVM.file.FileName;
                    await AddImageAsync(CreateVM);
                    TempData["success"] = "successfully Created";
                     return RedirectToAction("UpdateHouse", "House", new { id = Id });
                }
                  TempData["error"] = "Fail to Create!!";
              return NotFound();
        }


        public async Task<IActionResult> UpdateImage(int id)
        {
            var response = await _UnitService.ImageService.GetAsync<APIResponse>(id);


            if (response != null)
            {
                var result = JsonConvert.SerializeObject(response.Result);
                var dto = JsonConvert.DeserializeObject<HouseUpdateDTO>(result);
                return View(dto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImage(ImageUpdateDTO updateDTO)
        {
            if (ModelState.IsValid)
            {
                if (updateDTO != null)
                {
                    var response = await _UnitService.ImageService.UpdateAsync<APIResponse>(updateDTO);
                    if (response != null && response.IsSuccess)
                    {
                        _response.StatusCode = System.Net.HttpStatusCode.Created;
                        _response.IsSuccess = true;
                        TempData["success"] = "successfully Created";
                        return RedirectToAction(nameof(ImageIndex));

                    }

                    else
                    {
                        _response.ErrorMessages = new List<string> { "Error occurred during creation" };
                        _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        TempData["error"] = "Fail to Create!!";
                    }




                    return View(nameof(ImageIndex));


                }

            }
            return BadRequest();


        }
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("IndexHouse", "House");
            }
               var image = await _UnitService.ImageService.GetAsync<APIResponse>(id);
                if(image != null)
                {
                    var response = JsonConvert.SerializeObject(image.Result);
                    var dto = JsonConvert.DeserializeObject<ImageDTO>(Convert.ToString(response));
                    await _UnitService.ImageService.DeleteAsync<APIResponse>(id);
                    TempData["success"] = "successfully deleted";
                    return RedirectToAction("UpdateHouse", "House", new { id = dto.House_Id });

                }
               
            
            else
            {
                TempData["error"] = "Fail to delete!!";
                return RedirectToAction("IndexHouse", "House");
            }

          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteImage(ImageDTO model)
        {
            if (ModelState.IsValid)
            {
                
                var response = await _UnitService.ImageService.DeleteAsync<APIResponse>(model.Image_Id);
                if (response != null && response.IsSuccess)
                {
                    _response.StatusCode = System.Net.HttpStatusCode.Created;
                    _response.IsSuccess = true;
                    TempData["success"] = "successfully Created";
                    return RedirectToAction(nameof(ImageIndex));

                }

                else
                {
                    _response.ErrorMessages = new List<string> { "Error occurred during creation" };
                    _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    TempData["error"] = "Fail to Create!!";
                }


            }
            TempData["error"] = "Fail To Delete!!";
            return NotFound();
        }
        public async Task<ImageCreateVM> AddImageAsync(ImageCreateVM createVM)
        {


            if (createVM.file != null)
            {
                //foreach (var file in createVM.file)
                //{
                    var fileName = Guid.NewGuid().ToString() + "_" + createVM.file.FileName;
                    var upload = Path.Combine(_host.WebRootPath, @"Images");
                    var extention = Path.GetExtension(fileName);

                    var filePath = Path.Combine(upload, fileName);

                    using (var fileStreams = new FileStream(filePath, FileMode.Create))
                    {
                        createVM.file.CopyTo(fileStreams);
                    }

                    //var jsonResponse = JsonConvert.SerializeObject(createVM.file);
                    //var imageCreated = JsonConvert.DeserializeObject<ImageCreateDTO>(Convert.ToString(jsonResponse));
                   // createVM.CreateImage.fileName = createVM.file.FileName;
                    createVM.ImageList.fileName = @"\Images\" + fileName;
                   // createVM.CreateImage =imageCreated;


                  var responseImage = await _UnitService.ImageService.CreateAsync<APIResponse>(createVM.ImageList);

                //}
                return createVM;

            }

            return createVM;
        }


    }
}

