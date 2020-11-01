using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace IS_prueba_tecnica.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
