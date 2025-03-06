using Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Game.Infrastructure.Persistence.Configurations
{
    public class PartidaConfiguration : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.HasKey(e => e.IdPartida).HasName("PK__partida__42D83E726BCBD0EA");

            builder.ToTable("partida");

            builder.Property(e => e.IdPartida).HasColumnName("id_partida");
            builder.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            builder.Property(e => e.FechaInicio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            builder.Property(e => e.Ganador).HasColumnName("ganador");
            builder.Property(e => e.IdJugador1).HasColumnName("id_jugador1");
            builder.Property(e => e.IdJugador2).HasColumnName("id_jugador2");

            builder.HasOne(d => d.IdJugador1Navigation).WithMany(p => p.PartidumIdJugador1Navigations)
                .HasForeignKey(d => d.IdJugador1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__partida__id_juga__3D5E1FD2");

            builder.HasOne(d => d.IdJugador2Navigation).WithMany(p => p.PartidumIdJugador2Navigations)
                .HasForeignKey(d => d.IdJugador2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__partida__id_juga__3E52440B");

        }
    }
}
