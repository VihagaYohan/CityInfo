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
    }
}
