using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActualidadClientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gestor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numerotelefono = table.Column<string>(name: "Numero_telefono", type: "nvarchar(max)", nullable: false),
                    Contrato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Antiguedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Canaldeventa = table.Column<string>(name: "Canal_de_venta", type: "nvarchar(max)", nullable: false),
                    Articulos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipodecartera = table.Column<string>(name: "Tipo_de_cartera", type: "nvarchar(max)", nullable: false),
                    Diasdeatraso = table.Column<int>(name: "Dias_de_atraso", type: "int", nullable: false),
                    MontomensualFactura = table.Column<double>(name: "Monto_mensual_Factura", type: "float", nullable: false),
                    Saldototalcredito = table.Column<double>(name: "Saldo_total_credito", type: "float", nullable: false),
                    SaldoenMora = table.Column<double>(name: "Saldo_en_Mora", type: "float", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    Pagocondescuento = table.Column<double>(name: "Pago_con_descuento", type: "float", nullable: false),
                    Vencimientofactura = table.Column<DateTime>(name: "Vencimiento_factura", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualidadClientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fechagestion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Identidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoGestion = table.Column<string>(name: "Codigo_Gestion", type: "nvarchar(max)", nullable: false),
                    Descgestion = table.Column<string>(name: "Desc_gestion", type: "nvarchar(max)", nullable: false),
                    Montopromesa = table.Column<double>(name: "Monto_promesa", type: "float", nullable: false),
                    FechaPromesa = table.Column<DateTime>(name: "Fecha_Promesa", type: "datetime2", nullable: false),
                    Latitud = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mastergestion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idgestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescGestion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mastergestion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualidadClientes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "HistoricoClientes");

            migrationBuilder.DropTable(
                name: "Mastergestion");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
