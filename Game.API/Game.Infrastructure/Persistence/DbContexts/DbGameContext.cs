using System;
using System.Collections.Generic;
using Game.Application.Interfaces;
using Game.Domain.Entities;
using Game.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Game.Infrastructure.Persistence.DbContexts;

public partial class DbGameContext : DbContext, IApplicationDbContext
{
    public DbGameContext()
    {
    }

    public DbGameContext(DbContextOptions<DbGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jugador> Jugadors { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new JugadorConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
