using Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Game.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Jugador> Jugadors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
