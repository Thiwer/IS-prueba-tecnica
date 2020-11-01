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
    public class VehicleController : ApiControllerBase
    {
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle(CreateVehicleCommand request)
        {
            try
            {
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (VehicleExistsException veex)
            {
                return BadRequest($"The vehicle with Matrícula '{request.Matricula}' already exists.");
            }
            catch (DriverNotExistsException dneex)
            {
                return BadRequest($"The driver with DNI '{request.DNI}' does not exists.");
            }
            catch (VehiclesLimitException vlex)
            {
                return BadRequest($"The driver with DNI '{request.DNI}' cannot have more vehicles");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("infringement/{vehicleMatricula}/{infringementId}")]
        public async Task<IActionResult> RegisterInfringementToVehicle(string vehicleMatricula, int infringement, RegisterInfringementCommand request)
        {
            try
            {
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (VehicleNotExistsException vneex)
            {
                return BadRequest($"The vehicle with Matrícula '{request.Matricula}' does not exists.");
            }
            catch (InfringementNotExistsException ineex)
            {
                return BadRequest($"The Infringement with Id '{request.Id}' does not exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

}