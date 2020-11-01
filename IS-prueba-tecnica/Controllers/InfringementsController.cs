using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IS_prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfringementsController : ApiControllerBase
    {
        private readonly ILogger<InfringementsController> _logger;

        public InfringementsController(ILogger<InfringementsController> logger)
        {
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> CreateInfringement(CreateInfringementCommand request)
        {
            try
            {
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (InfringementExistsException ieex)
            {
                return BadRequest($"The Infringement with Id '{request.Id}' already exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
