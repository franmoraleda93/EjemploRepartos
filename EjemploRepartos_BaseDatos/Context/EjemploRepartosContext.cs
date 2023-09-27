using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EjemploRepartos_database.Entities;

namespace EjemploRepartos_database.Context
{
    public partial class EjemploRepartosContext : DbContext
    {
        public EjemploRepartosContext()
        {
        }

        public EjemploRepartosContext(DbContextOptions<EjemploRepartosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<MaeComida> MaeComida { get; set; } = null!;
        public virtual DbSet<MaeEstadoPedido> MaeEstadoPedido { get; set; } = null!;
        public virtual DbSet<Pedido> Pedido { get; set; } = null!;
        public virtual DbSet<PedidoComida> PedidoComida { get; set; } = null!;
        public virtual DbSet<Repartidor> Repartidor { get; set; } = null!;
        public virtual DbSet<Reparto> Reparto { get; set; } = null!;
        public virtual DbSet<RepartoUbicacion> RepartoUbicacion { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-Q5DTF3N\\SQLEXPRESS;Initial Catalog=EmpresaReparto;User ID=sqlrepartos;Password=Test1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaeComida>(entity =>
            {
                entity.Property(e => e.IdMaeComida).ValueGeneratedNever();
            });

            modelBuilder.Entity<MaeEstadoPedido>(entity =>
            {
                entity.Property(e => e.IdMaeEstadoPedido).ValueGeneratedNever();
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Cliente_IdCliente");

                entity.HasOne(d => d.IdEstadoPedidoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdEstadoPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_MaeEstadoPedido_IdEstadoPedido");
            });

            modelBuilder.Entity<PedidoComida>(entity =>
            {
                entity.HasKey(e => new { e.IdPedido, e.IdComida });

                entity.HasOne(d => d.IdComidaNavigation)
                    .WithMany(p => p.PedidoComida)
                    .HasForeignKey(d => d.IdComida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoComida_MaeComida_IdComida");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidoComida)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PedidoComida_Pedido_IdPedido");
            });

            modelBuilder.Entity<Reparto>(entity =>
            {
                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithOne(p => p.Reparto)
                    .HasForeignKey<Reparto>(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reparto_Pedido_IdPedido");

                entity.HasOne(d => d.IdRepartidorNavigation)
                    .WithMany(p => p.Reparto)
                    .HasForeignKey(d => d.IdRepartidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reparto_Repartidor_IdRepartidor");
            });

            modelBuilder.Entity<RepartoUbicacion>(entity =>
            {
                entity.HasOne(d => d.IdRepartoNavigation)
                    .WithMany(p => p.RepartoUbicacion)
                    .HasForeignKey(d => d.IdReparto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepartoUbicacion_Reparto_IdReparto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
