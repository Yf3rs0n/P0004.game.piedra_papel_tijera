using Game.Application.Interfaces;
using Game.Domain.Entities;
using MediatR;

namespace Game.Application.Commands
{
    public class InsertarJugadorCommand : IRequest<bool>
    {
        public string NombreJugador { get; set; }
    }
    public class InsertarJugadorCommandHandler : IRequestHandler<InsertarJugadorCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public InsertarJugadorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(InsertarJugadorCommand request, CancellationToken cancellationToken)
        {
            var jugador = new Jugador
            {
                NombreJugador = request.NombreJugador,
                FechaRegistro = DateTime.Now,
            };

            await _context.Jugadors.AddAsync(jugador, cancellationToken);
            var rows = await _context.SaveChangesAsync(cancellationToken);

            return rows > 0;
        }
    }
}
