using Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Jugador> Jugadors { get; set; }
        DbSet<Partida> Partida { get; set; }
        DbSet<Regla> Reglas { get; set; }
        DbSet<Ronda> Ronda { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
