using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/Dummy")]
    public class DummyController : Controller
    {
        private CityInfoContext _ctx;
        public DummyController(CityInfoContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet("TestDatabase")]
        public IActionResult TestDatabase()
        {

            return Ok();
        }
    }
}