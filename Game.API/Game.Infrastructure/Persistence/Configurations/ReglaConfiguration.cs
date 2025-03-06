using Game.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Persistence.Configurations
{
    public class ReglaConfiguration : IEntityTypeConfiguration<Regla>
    {
        public void Configure(EntityTypeBuilder<Regla> builder)
        {
            builder.HasKey(e => e.IdRegla).HasName("PK__regla__46D1C19249D82E7F");

            builder.ToTable("regla");

            builder.Property(e => e.IdRegla).HasColumnName("id_regla");
            builder.Property(e => e.Movimiento)
                .HasMaxLength(10)
                .HasColumnName("movimiento");
            builder.Property(e => e.VenceA)
                .HasMaxLength(10)
                .HasColumnName("vence_a");
        }
    }
}
