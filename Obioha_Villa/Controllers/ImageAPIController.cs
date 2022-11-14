using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Obioha_VillaAPI.Logger;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Models.DTO;
using Obioha_VillaAPI.Repository.IRepository;
using System.Net;

namespace Obioha_VillaAPI.Controllers
{
    [Route("api/ImageAPI")]
    [ApiController]
    public class ImageAPIController : ControllerBase
    {


        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IUnitOfWork _UOfWork;
        private readonly IMapper _mapper;

        public ImageAPIController(ILogging logger, IUnitOfWork uw, IMapper mapper)
        {
            _logger = logger;
            _UOfWork = uw;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet(Name = "GetAllImages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                IEnumerable<Image> Image_List = await _UOfWork.Image.GetAllAsync(includeProperties: "House");
                if (Image_List.Count() == 0 )
                {
                    _response.Result = "No Image exist in the database";
                    _response.ErrorMessages = new List<string> { "The table is empty!" };
                    _response.IsSuccess = false;
                    return NotFound(_response);

                }
                
                    _response.Result = _mapper.Map<List<ImageDTO>>(Image_List);
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

        [HttpGet("{id:int}", Name = "GetImage")]
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

                var image = await _UOfWork.Image.GetAsync(x => x.Image_Id == id);
                if (image == null)
                {
                    _response.Result = "No image exist with such id";
                    _response.ErrorMessages = new List<string> { "Id is not available!" };
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ImageDTO>(image);
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
        public async Task<ActionResult<APIResponse>> Create([FromBody] ImageCreateDTO CreateDTO)
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
                //if (await _UOfWork.Image.GetAsync(image => image.Image_Id == CreateDTO.Image_Id) == null)
                //{
                //    _response.ErrorMessages = new List<string> { "The Id does not exist in the primary table" };
                //    _response.IsSuccess = false;
                //    return BadRequest(_response);
                //}

                //converting imageUpdateDTO to image model
                var img = _mapper.Map<Image>(CreateDTO);

                await _UOfWork.Image.AddAsync(img);
                await _UOfWork.SaveAsync();

                //change back to dto because the return type is dto

                var imgDTO = _mapper.Map<ImageCreateDTO>(img);
                _response.Result = imgDTO;

                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetTenant", new { id = imgDTO.Image_Id }, _response); ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "deletedImage")]
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
                var img = await _UOfWork.Image.GetAsync(c => c.Image_Id == id);
                if (img == null)
                {
                    return NotFound("Object is not available");
                }
                await _UOfWork.Image.RemoveAsync(img);
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

        [HttpPut("{id:int}", Name = "UpdatedImage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Edit(int id, [FromBody] ImageUpdateDTO UpdateDTO)
        {
            try
            {
                if (id == 0 && UpdateDTO == null)
                {
                    return BadRequest("The Id's has to be same");
                }
                var img = _mapper.Map<Image>(UpdateDTO);

                await _UOfWork.Image.UpdateImageAsync(img);
                await _UOfWork.SaveAsync();
                _response.Result = _mapper.Map<ImageUpdateDTO>(img);
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

