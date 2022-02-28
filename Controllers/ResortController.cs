

using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacay.Models;
using Vacay.Services;

namespace Vacay.Controllers
{
    [ApiController]
    [Route("api/[controller")]

    public class ResortsController : ControllerBase
    {
        private readonly ResortsService _rs;

        public ResortsController(ResortsService rs)
        {
            _rs = rs;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Resort>> Get()
        {
            try
            {
                var resorts = _rs.Get();
                return Ok(resorts);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]

        public ActionResult<Resort> Create([FromBody] Resort newResort)
        {
            try
            {
                Resort resort = _rs.Create(newResort);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
        }
    }
}