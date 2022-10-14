using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obioha_VillaAPI.Data;
using Obioha_VillaAPI.Logger;
using Obioha_VillaAPI.Models;
using Obioha_VillaAPI.Models.DTO;
using System.Xml.Linq;

namespace Obioha_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    //[Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logger;
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ILogging logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetProperties()
        {
            _logger.Log("getting all villas", "Error");
            return Ok(_db.Houses);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(VillaDTO), 200)]
        public IActionResult GetProperty(int id)
        {

            if (id == 0)
            {
                _logger.Log("The Id cannot be empty ", "warning");
                return BadRequest("The Id is Zero!!");
            }

            var house = _db.Houses.FirstOrDefault(x => x.Id == id);
            if (house == null)
            {
                _logger.Log("The house cannot be null", "Information");
                return NotFound("the id does not exist");
            }
            return Ok(house); 
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public ActionResult CreateProperty([FromBody] HouseDTO houseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            if (houseDTO == null)
            {
                return NotFound("The object should not be empty!!");
            }
            if (houseDTO.Id > 0)
            {
                _logger.Log("id should be Testing creation", "");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            House house = new()
            {
                Name = houseDTO.Name,
                Built_Date = DateTime.Now,
                Current_Cost = houseDTO.Current_Cost,
                ImageUrl = houseDTO.ImageUrl,
                No_Of_Bedrooms = houseDTO.No_Of_Bedrooms,
                No_Of_Toilets = houseDTO.No_Of_Toilets,
                Occupancy = houseDTO.Occupancy,
                Property_Type = houseDTO.Property_Type,
                Purchased_Date = houseDTO.Purchased_Date,
                Purchase_Cost = houseDTO.Purchase_Cost,
                Purpose = houseDTO.Purpose,
                Sitting_Rooms_No = houseDTO.Sitting_Room_No,
                Square_Feet = houseDTO.Square_Feet


            };
            //if (_db.Houses.Any(x => x.Name == house.Name) != false)
            //{
            //    ModelState.AddModelError("Custom Error", "The Names has to be unique!");
            //    return BadRequest(ModelState);
            //}
            _db.Houses.Add(house);
            _db.SaveChanges();


            return CreatedAtRoute("GetVilla", new { id = house.Id } , house);
           // return NoContent();
        }

        [HttpDelete("{id:int}", Name = "deletedVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RemoveProperty(int id)
        {
            if (id == 0)
            {
                return BadRequest("Object to delete not found");
            }
            House house = _db.Houses.FirstOrDefault(c => c.Id == id);
            if (house == null)
            {
                return NotFound("Object is not available");
            }
            _db.Houses.Remove(house);
            _db.SaveChanges();

            //return CreatedAtRoute("deletedVilla",id,house);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdatedHouse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult EditProperty(int id, [FromBody] HouseDTO houseDTO)
        {
            if (id == 0 && houseDTO == null)
            {
                return BadRequest("The Id's has to be same");
            }
            House house = _db.Houses.FirstOrDefault(c => c.Id == id);
            if (house == null)
            {
                return NotFound("The house is not available!");
            }
            //update
               house= new House() {
                Name = houseDTO.Name,
                Built_Date = DateTime.Now,
                Current_Cost = houseDTO.Current_Cost,
                ImageUrl = houseDTO.ImageUrl,
                No_Of_Bedrooms = houseDTO.No_Of_Bedrooms,
                No_Of_Toilets = houseDTO.No_Of_Toilets,
                Occupancy = houseDTO.Occupancy,
                Property_Type = houseDTO.Property_Type,
                Purchased_Date = houseDTO.Purchased_Date,
                Purchase_Cost = houseDTO.Purchase_Cost,
                Purpose = houseDTO.Purpose,
                Sitting_Rooms_No = houseDTO.Sitting_Room_No,
                Square_Feet = houseDTO.Square_Feet
            };
             _db.Houses.Update(house);
            _db.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id:int}", Name = "PartialUpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PatialEditProperty(int id, JsonPatchDocument<HouseDTO> jsonPatch)
        {
            if (id == 0 && jsonPatch == null)
            {
                return BadRequest("verify the id and jsonPatch");
            }

            House house = _db.Houses.FirstOrDefault(villa => villa.Id == id);
            if (house == null)
            {
                return BadRequest("Villa not found");
            }
            //change to DTO
            HouseDTO houseDTO = new()
            {    Id = house.Id,
                Name = house.Name,
                Built_Date = DateTime.Now,
                Current_Cost = house.Current_Cost,
                ImageUrl = house.ImageUrl,
                No_Of_Bedrooms = house.No_Of_Bedrooms,
                No_Of_Toilets = house.No_Of_Toilets,
                Occupancy = house.Occupancy,
                Property_Type = house.Property_Type,
                Purchased_Date = house.Purchased_Date,
                Purchase_Cost = house.Purchase_Cost,
                Purpose = house.Purpose,
                Sitting_Room_No = house.Sitting_Rooms_No,
                Square_Feet = house.Square_Feet

            };
            jsonPatch.ApplyTo(houseDTO, ModelState);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("customError", "the model error");
            }
            //update
          House  houseToApply = new House()
            {
                Name = houseDTO.Name,
                Built_Date = DateTime.Now,
                Current_Cost = houseDTO.Current_Cost,
                ImageUrl = houseDTO.ImageUrl,
                No_Of_Bedrooms = houseDTO.No_Of_Bedrooms,
                No_Of_Toilets = houseDTO.No_Of_Toilets,
                Occupancy = houseDTO.Occupancy,
                Property_Type = houseDTO.Property_Type,
                Purchased_Date = houseDTO.Purchased_Date,
                Purchase_Cost = houseDTO.Purchase_Cost,
                Purpose = houseDTO.Purpose,
                Sitting_Rooms_No = houseDTO.Sitting_Room_No,
                Square_Feet = houseDTO.Square_Feet
            };
            _db.Houses.Update(houseToApply);
            _db.SaveChanges();
            return NoContent();


        }



    }
}
