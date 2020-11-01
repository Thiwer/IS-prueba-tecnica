using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IS_prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ApiControllerBase
    {
        private readonly ILogger<DriversController> _logger;

        public DriversController(ILogger<DriversController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(CreateDriverCommand request)
        {
            try
            {
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (DriverExistsException drex)
            {
                return BadRequest($"The driver with DNI '{request.DNI}' already exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
