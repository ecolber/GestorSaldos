using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PTNF.Models;

public partial class PruebaTecNfContext : DbContext
{
    public PruebaTecNfContext()
    {
    }

    public PruebaTecNfContext(DbContextOptions<PruebaTecNfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cuenta> Cuentas { get; set; }

    public virtual DbSet<GestorSaldo> GestorSaldos { get; set; }

    public virtual DbSet<Gestore> Gestores { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.Property(e => e.NombreCta).HasMaxLength(50);
            entity.Property(e => e.Saldo).HasColumnType("numeric(18, 2)");
        });

        modelBuilder.Entity<GestorSaldo>(entity =>
        {
            entity.ToTable("GestorSaldo");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.GestorSaldos)
                .HasForeignKey(d => d.CuentaId)
                .HasConstraintName("FK_GestorSaldo_Cuentas");

            entity.HasOne(d => d.Gestor).WithMany(p => p.GestorSaldos)
                .HasForeignKey(d => d.GestorId)
                .HasConstraintName("FK_GestorSaldo_Gestores");
        });

        modelBuilder.Entity<Gestore>(entity =>
        {
            entity.HasKey(e => e.GestorId);

            entity.Property(e => e.Nombre).HasMaxLength(200);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
