using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SETEC.Migrations
{
    public partial class _2time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualidadClientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gestor = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Antiguedad = table.Column<string>(type: "text", nullable: false),
                    Canal_de_venta = table.Column<string>(type: "text", nullable: false),
                    Articulos = table.Column<string>(type: "text", nullable: false),
                    Tipo_de_cartera = table.Column<string>(type: "text", nullable: false),
                    Dias_de_atraso = table.Column<int>(type: "integer", nullable: false),
                    Monto_mensual_Factura = table.Column<double>(type: "double precision", nullable: false),
                    Saldo_total_credito = table.Column<double>(type: "double precision", nullable: false),
                    Saldo_en_Mora = table.Column<double>(type: "double precision", nullable: false),
                    Descuento = table.Column<double>(type: "double precision", nullable: false),
                    Pago_con_descuento = table.Column<double>(type: "double precision", nullable: false),
                    Vencimiento_factura = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualidadClientes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualidadClientes");
        }
    }
}
