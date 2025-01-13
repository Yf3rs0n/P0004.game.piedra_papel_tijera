using Game.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Game.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JugadorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-students")]
        public async Task<IActionResult> Get()
        {
            var estudiantes = await _mediator.Send(new ConsultarJugadoresQuery());
            return Ok(estudiantes);
        }
    }
}
