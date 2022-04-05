using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuraciones
{
    public class PedidosDetConfig : IEntityTypeConfiguration<PedidoDet>
    {
        public void Configure(EntityTypeBuilder<PedidoDet> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("PedidoDet");

            builder.HasComment("Listado de Pedidos");

            builder.HasIndex(p => p.ClienteId, "IX_PedidoDet_Cliente");

            builder.HasIndex(p => p.ProdMaestroId, "IX_PedidoDet_ProdMaestro");

            builder.HasIndex(p => p.MarcaId, "IX_PedidoDet_Marca");

            // builder.HasIndex(p => new { p.ClienteId, p.ProdMaestroId, p.MarcaId }, "IX_NoDuplicado").IsUnique();

            builder.Property(p => p.Id).HasComment("Id Consecutivo del pedido");

            builder.Property(p => p.Estatus)
                .IsRequired()
                .HasDefaultValue(EstatusPedido.Pendiente)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Estatus del articulo del Pedidio , P = Pendiente, F = Facturado");

            builder.Property(p => p.FechaDeCreacion)
                .HasColumnType("datetime2")
                .HasComment("Fecha de Creacion");

            builder.Property(p => p.UsuarioCreacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("Nombre del Usuario que Creo el registro");

            builder.Property(p => p.FechaModificacion)
                .HasColumnType("datetime2")
                .HasComment("Fecha de Modificacion");

            builder.Property(p => p.UsuarioModificacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("Nombre del Usuario que hizo la ultima modificacion de el registro");

            builder.Property(p => p.Cantidad)
                .IsRequired()
                .HasPrecision(precision: 6, scale: 3)
                .HasComment("Cantidad de Articulos del Registro del pedido");

            builder.Property(p => p.ClienteId)
                .IsRequired()
                .HasComment("El id del Cliente");

            builder.Property(p => p.EmpleadoId)
                .IsRequired()
                .HasComment("El id del Empleado");

            builder.Property(p => p.Cantidad)
                .IsRequired()
                .HasComment("Cantidad solicitada");

            builder.Property(p => p.ProdMaestroId)
                .IsRequired()
                .HasComment("Id del catalogo de ProdMaestro");

            builder.Property(p => p.MarcaId)
                .IsRequired()
                .HasComment("Id del Catalogo de Marcas");

            builder.Property(p => p.EsCadaUno)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Si el precio es por unidad y no por caja");

            builder.Property(p => p.Notas)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Notas para el que va a surtir el reglon del Pedido");
        }

    }
}
