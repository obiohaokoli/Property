using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Logger;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Models.DTO;
using Obioha_VillaAPI.Repository.IRepository;
using System.Net;
using System.Xml.Linq;

namespace Obioha_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    //[Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IUnitOfWork _UOfWork;
        private readonly IMapper _mapper;
      
        public VillaAPIController(ILogging logger, IUnitOfWork uw, IMapper mapper)
        {
            _logger = logger;
            _UOfWork = uw;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet(Name ="GetAllHouses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetHouses()
        {
            try
            {
                IEnumerable<House> houseList = await _UOfWork.House.GetAllAsync();
                _response.Result = _mapper.Map<List<HouseDTO>>(houseList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(VillaDTO), 200)]
        public async Task<ActionResult<APIResponse>> GetHouse(int id)
        {
            try { 
        if (id == 0)
            {
                   return BadRequest("Id cannot be zero!");
            }

            var house = await _UOfWork.House.GetAsync(x => x.Id == id);
            if (house == null)
            {
                return NotFound("the object does not exist");
            }
           _response.Result= _mapper.Map<HouseDTO>(house);
            _response.StatusCode = HttpStatusCode.OK;
            return  Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult<APIResponse>> CreateProperty([FromBody] HouseCreateDTO houseCreateDTO)
        {
            try { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (houseCreateDTO == null)
            {
                return NotFound("The object should not be empty!!");
            }
            //converting houseUpdateDTO to House model
          House house =  _mapper.Map<House>(houseCreateDTO);
           await _UOfWork.House.AddAsync(house);
            await _UOfWork.SaveAsync();

            //change back to dto because the return type is dto
           _response.Result = _mapper.Map<HouseCreateDTO>(house);
         CreatedAtRoute("GetVilla", new { id = house.Id } , _response);
            _response.StatusCode = HttpStatusCode.Created;
            return  _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "deletedVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> RemoveProperty(int id)
        {
            try { 
            if (id == 0)
            {
                return BadRequest("Object to delete not found");
            }
            House house =await _UOfWork.House.GetAsync(c => c.Id == id);
            if (house == null)
            {
                return NotFound("Object is not available");
            }
           await _UOfWork.House.RemoveAsync(house);
                await _UOfWork.SaveAsync();
                //return CreatedAtRoute("deletedVilla",id,house);
                _response.StatusCode = HttpStatusCode.NoContent;
            return  _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdatedHouse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> EditProperty(int id, [FromBody] HouseUpdateDTO houseUpdateDTO)
        {
            try { 
            if (id == 0 && houseUpdateDTO == null)
            {
                return BadRequest("The Id's has to be same");
            }
              House house = _mapper.Map<House>(houseUpdateDTO);
           
           await _UOfWork.House.UpdateHouseAsync(house);
                await _UOfWork.SaveAsync();
                _response.Result = _mapper.Map<HouseUpdateDTO>(house);
            _response.StatusCode = HttpStatusCode.NoContent;
            return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpPatch("{id:int}", Name = "PartialUpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> PatialEdit(int id, JsonPatchDocument<HouseUpdateDTO> jsonPatch)
        {
            try { 
            if (id == 0 && jsonPatch == null)
            {
                return BadRequest("verify the id and jsonPatch");
            }

        House house = await _UOfWork.House.GetAsync(villa => villa.Id == id,
            tracked:false);

            if (house == null)
            {
                return BadRequest("Villa not found");
            }
            //change house mode to houseUpdateDTO
            HouseUpdateDTO updateDTO = _mapper.Map<HouseUpdateDTO>(house);
        
            jsonPatch.ApplyTo(updateDTO, ModelState);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("customError", "the model error");
            }
            //convert from HouseUpdateDTO to House Model
            House houseUpdate = _mapper.Map<House>(updateDTO);
         
           await _UOfWork.House.UpdateHouseAsync(houseUpdate);
            await _UOfWork.SaveAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
            return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;


        }



    }
}
