using Game.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Infrastructure.Persistence.Configurations
{
    public class RondaConfiguration : IEntityTypeConfiguration<Ronda>
    {
        public void Configure(EntityTypeBuilder<Ronda> builder)
        {
            builder.HasKey(e => e.IdRonda).HasName("PK__ronda__3FB76BCD86598061");

            builder.ToTable("ronda");

            builder.Property(e => e.IdRonda).HasColumnName("id_ronda");
            builder.Property(e => e.IdPartida).HasColumnName("id_partida");
            builder.Property(e => e.IdRegla).HasColumnName("id_regla");
            builder.Property(e => e.MovimientoJugador1)
                .HasMaxLength(10)
                .HasColumnName("movimiento_jugador1");
            builder.Property(e => e.MovimientoJugador2)
                .HasMaxLength(10)
                .HasColumnName("movimiento_jugador2");
            builder.Property(e => e.Resultado)
                .HasMaxLength(10)
                .HasColumnName("resultado");
            builder.Property(e => e.RondaNumero).HasColumnName("ronda_numero");

            builder.HasOne(d => d.IdPartidaNavigation).WithMany(p => p.Ronda)
                .HasForeignKey(d => d.IdPartida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ronda__id_partid__412EB0B6");

            builder.HasOne(d => d.IdReglaNavigation).WithMany(p => p.Ronda)
                .HasForeignKey(d => d.IdRegla)
                .HasConstraintName("FK__ronda__id_regla__4222D4EF");

        }
        
    }
}
