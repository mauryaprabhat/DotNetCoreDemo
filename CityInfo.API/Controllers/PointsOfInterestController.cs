using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/")]
    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;
        private IMailService _mailService;
        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;

        }

        [HttpGet("{cityid}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
               
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.ID == cityId);
                if (city == null)
                {
                    _logger.LogInformation($"City with id {cityId} was not found when accessing points of interest");
                    return NotFound();
                }
                return Ok(city.PointsOfInterests);
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.",ex.Message);
                return StatusCode(500, "A problem happened while handling your request");
            }
       
        }

        [HttpGet("{cityID}/pointsofinterest/{id}")]
        public IActionResult GetPointofInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.ID == cityId);
            if (city == null)
            {
                _logger.LogInformation($"City with id {cityId} was not found when accessing points of interest");
                return NotFound();
            }

            var pointsofinterest = city.PointsOfInterests.FirstOrDefault(p => p.Id == id);
            if (pointsofinterest == null)
            {
                return NotFound();
            }
            return Ok(pointsofinterest);
        }
        //[HttpPost("{cityId}/pointsofinterest")]
        //public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointsOfDtoforCreation pointofInterest)
        //{
        //    if(pointofInterest == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityId);
        //    if(city == null)
        //    {
        //        return NotFound();
        //    }
        //    var maxPointofInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterests).Max(x => x.Id);

        // }

        [HttpPut("{cityid}/pointsofinterest/{id}")]
        public IActionResult UpdatePointsOfInterest(int cityid, int id, [FromBody]PointsOfInterestforUpdate pointofInterest)
        {
            if (pointofInterest == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityid);
            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointsOfInterests.FirstOrDefault(x => x.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            pointOfInterestFromStore.Name = pointofInterest.Name;
            pointOfInterestFromStore.Description = pointofInterest.Description;

            return NoContent();
        }

        [HttpPatch("{cityID}/pointsofinterest/{id}")]
        public IActionResult PatchPointsOfInterest(int cityId, int id, [FromBody] JsonPatchDocument<PointsOfInterestforUpdate> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterestFromStore = city.PointsOfInterests.FirstOrDefault(x => x.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            var pointOfInterestToPatch = new PointsOfInterestforUpdate()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description
            };
            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
        [HttpDelete("{cityId}/pointsofInterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityId);
            if(city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterests.FirstOrDefault(c => c.Id == id);
            if(pointOfInterestFromStore == null)
            {
                return NotFound();
            }
            city.PointsOfInterests.Remove(pointOfInterestFromStore);
            _mailService.send("Point of interest deleted", $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted");

            return NoContent();
        }
    }
}
