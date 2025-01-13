using Game.Application.Interfaces;
using Game.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Application.Queries
{
    public class ConsultarJugadoresQuery: IRequest<List<Jugador>> { }
    public class ConsultarJugadoresQueryHandler : IRequestHandler<ConsultarJugadoresQuery, List<Jugador>> { 
    
        private readonly IApplicationDbContext _context;
        public ConsultarJugadoresQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Jugador>> Handle(ConsultarJugadoresQuery request, CancellationToken cancellationToken)
        {
            return await _context.Jugadors.ToListAsync(cancellationToken);
        }
    }
}
