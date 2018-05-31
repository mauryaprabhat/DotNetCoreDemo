using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            //return new JsonResult(new List<object>()
            //{
            //    new { id =1, Name="New York City"},
            //    new { id=2, Name="Mumbai"}
            //});
            return new JsonResult(CitiesDataStore.Current.Cities);
        }
        //[HttpGet("GetCity/{id}")]
        //public JsonResult GetCity(int id)
        //{
        //     return new JsonResult(CitiesDataStore.Current.Cities.Where(x=>x.ID == id).ToList());
        //    //return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault());
        //}            
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var data = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.ID == id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}