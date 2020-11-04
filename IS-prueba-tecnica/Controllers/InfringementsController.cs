using IS_prueba_tecnica.Application.Common.Exceptions;
using IS_prueba_tecnica.Application.Infringements.Commands.CreateInfringement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
            catch (InfringementExistsException)
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
