using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Logger;
using Obioha_VillaAPI.Models.DTO;

namespace Obioha_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    //[Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging  _logger;
        public VillaAPIController(ILogging logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            _logger.Log("getting all villas", "Error");
            return Ok(VillaStore.VillaList);
        }

        [HttpGet("{id:int}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
      //[ProducesResponseType(typeof(VillaDTO), 200)]
        public IActionResult GetSingleVilla(int id)
        {
            
            if (id == 0)
            {
                _logger.Log("The Id cannot be empty ", "warning");
                return BadRequest("The Id is Zero!!");
            }

           var villa = VillaStore.VillaList.FirstOrDefault(x => x.Id == id);
            if(villa == null)
            {
                _logger.Log("The villa cannot be null", "Information");
                return NotFound("the id does not exist");
            }
            else { return Ok(villa); }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> AddVilla([FromBody] VillaDTO villaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (VillaStore.VillaList.Any(x => x.Name == villaDTO.Name) != false)
            {
               ModelState.AddModelError("Custom Error", "The Names has to be unique!");
                return BadRequest(ModelState);
            }
                if (villaDTO == null)
            {
                return NotFound("The object should not be empty!!");
            }
            if (villaDTO.Id > 0)
            {    _logger.Log("id should be Testing creation", "");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = VillaStore.VillaList
                                    .OrderByDescending(x => x.Id)
                                    .First().Id + 1;

            VillaStore.VillaList.Add(villaDTO);
            return CreatedAtRoute("GetVilla", new{id = villaDTO.Id}, villaDTO);
        }

        [HttpDelete("{id:int}",Name ="deletedVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest("Object to delete not found");
            }
           VillaDTO villa =  VillaStore.VillaList.FirstOrDefault(c => c.Id == id);
            if (villa == null)
            {
                return NotFound("Object is not available");
            }
            VillaStore.VillaList.Remove(villa);

            //return CreatedAtRoute("deletedVilla",id,villa);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdatedVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult EditVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if(id == 0 && villaDTO == null)
            {
                return BadRequest("The Id's has to be same");
            }
            var villa = VillaStore.VillaList.FirstOrDefault(c => c.Id == id);
            if(villa == null)
            {
                return NotFound("The villa is not available!");
            }
            //update
            villa.Name = villaDTO.Name;
            villa.Occupancy = villaDTO.Occupancy;
            villa.Sqtf = villaDTO.Sqtf;

            return NoContent();
               
        }

        [HttpPatch("{id:int}", Name = "PartialUpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PatchVilla(int id, JsonPatchDocument<VillaDTO> jsonPatch)
        {
            if(id == 0 && jsonPatch == null)
            {
                return BadRequest("verify the id and jsonPatch");
            }
       
             VillaDTO patchVilla = VillaStore.VillaList.FirstOrDefault(villa => villa.Id == id);
            if(patchVilla == null)
            {
                return BadRequest("Villa not found");
            }
            jsonPatch.ApplyTo(patchVilla, ModelState);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("customError", "the model error");
            }
            return NoContent();


        }



    }
}
