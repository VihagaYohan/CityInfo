using CityInfo.API.Context;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ILocalMainService _mailService;
        private readonly CityInfoContext _context;

        public CitiesController(ILocalMainService mailService,
            CityInfoContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        // orginal hardcoded GetCities endpoint
        //[HttpGet]
        //public JsonResult GetCities()
        //{
        //    return new JsonResult(new List<object> {
        //        new { id = 1, name = "Colombo"},
        //        new { id = 2, name = "Kandy"},
        //        new { id = 3, name = "Wattala"}
        //    });
        //}

        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            var cities = _context.Cities
                .OrderBy(c => c.Name)
                .Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToList();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // orginal hardcode lookup
            //if (id == 1)
            //{

            //    this._mailService.SendMail();

            //    return Ok(new CityDto
            //    {
            //        Id = 1,
            //        Name = "Colombo",
            //        Description = "Commercial capital and larget city of Sri Lanka"
            //    });
            //}

            //return NotFound();

            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(new CityDto { Id = city.Id, Name = city.Name, Description = city.Description });
        }
    }
}
