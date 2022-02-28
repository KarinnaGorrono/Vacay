using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacay.Models;
using Vacay.Services;

namespace Vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CruisesController : ControllerBase
    {
        private readonly CruisesService _cs;

        public CruisesController(CruisesService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cruise>> Get()
        {
            try
            {
                var cruises = _cs.Get();
                return Ok(cruises);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Cruise> Create([FromBody] Cruise newCruise)
        {
            try
            {
                Cruise cruise = _cs.Create(newCruise);
                return Ok(cruise);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}