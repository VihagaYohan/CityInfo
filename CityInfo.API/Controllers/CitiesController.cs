using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ILocalMainService _mailService;

        public CitiesController(ILocalMainService mailService) {
            _mailService = mailService;
        }

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

                this._mailService.SendMail();

                return Ok(new CityDto { 
                Id = 1,
                Name = "Colombo",
                Description = "Commercial capital and larget city of Sri Lanka"});
            }

            return NotFound();
        }
    }
}
