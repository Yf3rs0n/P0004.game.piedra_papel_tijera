using Game.Application.Commands;
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

        [HttpGet("get-jugadores")]
        public async Task<IActionResult> Get()
        {
            var jugadores = await _mediator.Send(new ConsultarJugadoresQuery());
            return Ok(jugadores);
        }
        [HttpPost("insert-jugador")]
        public async Task<IActionResult> InsertarJugador([FromBody] InsertarJugadorCommand command)
        {
            if (command == null || string.IsNullOrWhiteSpace(command.NombreJugador))
            {
                return BadRequest("El nombre del jugador no puede estar vacío.");
            }

            var resultado = await _mediator.Send(command);

            if (resultado)
            {
                return Ok("Jugador insertado exitosamente.");
            }

            return StatusCode(500, "Hubo un problema al insertar el jugador.");
        }

    }
}
