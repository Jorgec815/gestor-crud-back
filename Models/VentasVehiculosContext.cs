using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gestor_crud_back.Models;

public partial class VentasVehiculosContext : DbContext
{
    public VentasVehiculosContext()
    {
    }

    public VentasVehiculosContext(DbContextOptions<VentasVehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Concesionario> Concesionarios { get; set; }

    public virtual DbSet<Transacciones> Transacciones { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7B39FA1DE");

            entity.Property(e => e.ClienteId)
                .ValueGeneratedNever()
                .HasColumnName("ClienteID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Concesionario>(entity =>
        {
            entity.HasKey(e => e.ConcesionarioId).HasName("PK__Concesio__CFF65D10448F65D0");

            entity.Property(e => e.ConcesionarioId)
                .ValueGeneratedNever()
                .HasColumnName("ConcesionarioID");
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Transacciones>(entity =>
        {
            entity.HasKey(e => e.TransaccionId).HasName("PK__Transacc__86A849DEF8531647");

            entity.Property(e => e.TransaccionId)
                .ValueGeneratedNever()
                .HasColumnName("TransaccionID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.ConcesionarioId).HasColumnName("ConcesionarioID");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_CLIENTEID");

            entity.HasOne(d => d.Concesionario).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.ConcesionarioId)
                .HasConstraintName("FK_CONCESIONARIOID");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.VehiculoId)
                .HasConstraintName("FK_VEHICULOID");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA08862052A7D1D8");

            entity.Property(e => e.VehiculoId)
                .ValueGeneratedNever()
                .HasColumnName("VehiculoID");
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
