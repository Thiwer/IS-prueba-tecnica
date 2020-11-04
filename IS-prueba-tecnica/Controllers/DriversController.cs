using IS_prueba_tecnica.Application.Common.Exceptions;
using IS_prueba_tecnica.Application.Drivers.Commands.CreateDriver;
using IS_prueba_tecnica.Application.Drivers.Queries.GetDrivers;
using IS_prueba_tecnica.Application.Drivers.Queries.GetHIstory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
            catch (DriverExistsException)
            {
                return BadRequest($"The driver with DNI '{request.Dni}' already exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("infringements/{dni}")]
        public async Task<IActionResult> GetInfringements(string dni)
        {
            try
            {
                var request = new GetHistoryQuery
                {
                    DriverDni = dni
                };
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("drivers/{number}")]
        public async Task<IActionResult> GetDrivers(int number)
        {
            try
            {
                var request = new GetDriversQuery
                {
                    NumDrivers = number
                };
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
