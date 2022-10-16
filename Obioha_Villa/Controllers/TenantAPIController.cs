using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Obioha_VillaAPI.Logger;
using Obioha_VillaAPI.Models.DTO;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Repository.IRepository;
using System.Net;

namespace Obioha_VillaAPI.Controllers
{
    [Route("api/TenantAPI")]
    [ApiController]
    public class TenantAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IUnitOfWork _UOfWork;
        private readonly IMapper _mapper;

        public TenantAPIController(ILogging logger, IUnitOfWork uw, IMapper mapper)
        {
            _logger = logger;
            _UOfWork = uw;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet(Name = "GetAllTenant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                IEnumerable<Tenant> tenantList = await _UOfWork.Tenant.GetAllAsync(includeProperties:"House");
                if(tenantList.Count() == 0)
                {
                    _response.Result = "No Tenant exist in the database" ;
                    _response.ErrorMessages = new List<string> {"The table is empty!" };
                    _response.IsSuccess = false;
                    return NotFound(_response);

                }
                _response.Result = _mapper.Map<List<TenantDTO>>(tenantList);
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

        [HttpGet("{id:int}", Name = "GetTenant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(VillaDTO), 200)]
        public async Task<ActionResult<APIResponse>> GetSingle(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Id cannot be zero!");
                }

                var tenant = await _UOfWork.Tenant.GetAsync(x => x.Id == id);
                if (tenant == null)
                {
                    _response.Result = "No Tenant exist with such id";
                    _response.ErrorMessages = new List<string> { "Id is not available!" };
                    _response.IsSuccess=false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<TenantDTO>(tenant);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult<APIResponse>> Create([FromBody] TenantCreateDTO CreateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (CreateDTO == null)
                {
                    return NotFound("The object should not be empty!!");
                }
                if (await _UOfWork.House.GetAsync(house => house.Id == CreateDTO.House_Id) == null)
                {
                    _response.ErrorMessages = new List<string> { "The Id does not exist in the primary table" };
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                //converting houseUpdateDTO to House model
                var tenant = _mapper.Map<Tenant>(CreateDTO);
              
               await _UOfWork.Tenant.AddAsync(tenant);
                await _UOfWork.SaveAsync();

                //change back to dto because the return type is dto
              
                    var tenantDTO = _mapper.Map<TenantCreateDTO>(tenant);
                _response.Result = tenantDTO;
               
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetTenant", new { id = tenantDTO.Id}, _response); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "deletedTenat")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Remove(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Object to delete not found");
                }
                var tenant = await _UOfWork.Tenant.GetAsync(c => c.Id == id);
                if (tenant == null)
                {
                    return NotFound("Object is not available");
                }
                await _UOfWork.Tenant.RemoveAsync(tenant);
               await _UOfWork.SaveAsync();
                //return CreatedAtRoute("deletedVilla",id,house);
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

        [HttpPut("{id:int}", Name = "UpdatedTenant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Edit(int id, [FromBody] TenantUpdateDTO UpdateDTO)
        {
            try
            {
                if (id == 0 && UpdateDTO == null)
                {
                    return BadRequest("The Id's has to be same");
                }
                var tenant = _mapper.Map<Tenant>(UpdateDTO);

                await _UOfWork.Tenant.UpdateTenantAsync(tenant);
              await _UOfWork.SaveAsync();
                _response.Result = _mapper.Map<TenantUpdateDTO>(tenant);
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

        [HttpPatch("{id:int}", Name = "PartialUpdateTenant")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> PatialEdit(int id, JsonPatchDocument<TenantUpdateDTO> jsonPatch)
        {
            try
            {
                if (id == 0 && jsonPatch == null)
                {
                    return BadRequest("verify the id and jsonPatch");
                }

                var tenant = await _UOfWork.Tenant.GetAsync(villa => villa.Id == id,
                    tracked: false);

                if (tenant == null)
                {
                    return BadRequest("Villa not found");
                }
                //change house mode to houseUpdateDTO
                var updateDTO = _mapper.Map<TenantUpdateDTO>(tenant);

                jsonPatch.ApplyTo(updateDTO, ModelState);
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("customError", "the model error");
                }
                //convert from HouseUpdateDTO to House Model
                var tenantUpdate = _mapper.Map<Tenant>(updateDTO);

                await _UOfWork.Tenant.UpdateTenantAsync(tenantUpdate);
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

