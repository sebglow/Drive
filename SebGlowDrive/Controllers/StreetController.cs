using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SebGlowDrive.Model;
using SebGlowDrive.Services;
using Microsoft.AspNetCore.Mvc;

namespace SebGlowDrive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        private IStreetService streetService;

        public StreetController(IStreetService streetService)
        {
            this.streetService = streetService;
        }

        // GET api/street
        [HttpGet]
        public ActionResult<IEnumerable<Street>> Get()
        {
            var result = streetService.GetAll();

            if (result == null)
                return NotFound(result);
            else
                return Ok(result);
        }

        // GET api/closest?x={x}&y={y}
        [HttpGet("/api/closest")]
        public ActionResult<Street> Get([FromQuery] double x, [FromQuery] double y)
        {
            var result = streetService.FindNearest(x, y);

            return Ok(result);
        }

        // POST api/street
        [HttpPost]
        public void Post([FromBody] Street street)
        {
            this.streetService.AddStreet(street);
        }
    }
}
