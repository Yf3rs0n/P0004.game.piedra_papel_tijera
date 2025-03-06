using Game.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers
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
        [HttpGet("get-jugadores")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new());
            return Ok(result);
        }
        [HttpPost("insert-jugador")]
        public async Task<IActionResult> Post([FromBody] InsertarJugadorCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Success ? Ok(response) : BadRequest(response);

        }
    }
}