using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object> {
                new { id = 1, name = "Colombo"},
                new { id = 2, name = "Kandy"},
                new { id = 3, name = "Wattala"}
            });
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id == 1) {
                return Ok(new CityDto { 
                Id = 1,
                Name = "Colombo",
                Description = "Commercial capital and larget city of Sri Lanka"});
            }

            return NotFound();
        }
    }
}
