using Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Infrastructure.Persistence.Configurations
{
    public class JugadorConfiguration : IEntityTypeConfiguration<Jugador>
    {
        public void Configure(EntityTypeBuilder<Jugador> builder)
        {
            builder.HasKey(e => e.IdJugador).HasName("PK__jugador__75BB83E277F32573");

            builder.ToTable("jugador");

            builder.Property(e => e.IdJugador).HasColumnName("id_jugador");
            builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            builder.Property(e => e.NombreJugador)
                .HasMaxLength(100)
                .HasColumnName("nombre_jugador");
        }
    }
}
