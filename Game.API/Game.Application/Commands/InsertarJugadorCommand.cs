using AutoMapper;
using Game.Application.Common;
using Game.Application.DTOs;
using Game.Application.Interfaces;
using Game.Domain.Entities;
using MediatR;

namespace Game.Application.Commands
{
    public record InsertarJugadorCommand(string nombreJugador) : IRequest<ApiResponse<JugadorDto>>;

    public class InsertarJugadorCommandHandler(IApplicationDbContext context, IMapper mapper): IRequestHandler<InsertarJugadorCommand, ApiResponse<JugadorDto>>
    {
        private readonly IApplicationDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ApiResponse<JugadorDto>> Handle(InsertarJugadorCommand request, CancellationToken cancellationToken)
        {
            var jugador = new Jugador
            {
                NombreJugador = request.nombreJugador
            };

            _context.Jugadors.Add(jugador);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;

            var jugadorDto = _mapper.Map<JugadorDto>(jugador);

            return result
                ? new ApiResponse<JugadorDto>("Jugador insertado correctamente", true, jugadorDto)
                : new ApiResponse<JugadorDto>("Error al insertar el jugador", false, null);
        }
    }
}

