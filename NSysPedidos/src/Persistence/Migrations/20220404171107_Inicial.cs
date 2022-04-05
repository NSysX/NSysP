using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PedidoDet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Id Consecutivo del pedido")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Pendiente", comment: "Estatus del articulo del Pedidio , P = Pendiente, F = Facturado"),
                    ClienteId = table.Column<int>(type: "int", nullable: false, comment: "El id del Cliente"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false, comment: "El id del Empleado"),
                    Cantidad = table.Column<decimal>(type: "decimal(6,3)", precision: 6, scale: 3, nullable: false, comment: "Cantidad solicitada"),
                    ProdMaestroId = table.Column<int>(type: "int", nullable: false, comment: "Id del catalogo de ProdMaestro"),
                    MarcaId = table.Column<int>(type: "int", nullable: false, comment: "Id del Catalogo de Marcas"),
                    EsCadaUno = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Si el precio es por unidad y no por caja"),
                    Notas = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, comment: "Notas para el que va a surtir el reglon del Pedido"),
                    UsuarioCreacion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, comment: "Nombre del Usuario que Creo el registro"),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Fecha de Creacion"),
                    UsuarioModificacion = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, comment: "Nombre del Usuario que hizo la ultima modificacion de el registro"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha de Modificacion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDet", x => x.Id);
                },
                comment: "Listado de Pedidos");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDet_Cliente",
                table: "PedidoDet",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDet_Marca",
                table: "PedidoDet",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDet_ProdMaestro",
                table: "PedidoDet",
                column: "ProdMaestroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoDet");
        }
    }
}
