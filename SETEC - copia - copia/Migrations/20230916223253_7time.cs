using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SETEC.Migrations
{
    public partial class _7time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActualidadCliente",
                table: "ActualidadCliente");

            migrationBuilder.RenameTable(
                name: "ActualidadCliente",
                newName: "ActualidadClientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActualidadClientes",
                table: "ActualidadClientes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "HistoricoClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fechagestion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Identidad = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Contrato = table.Column<string>(type: "text", nullable: false),
                    Codigo_Gestion = table.Column<string>(type: "text", nullable: false),
                    Desc_gestion = table.Column<string>(type: "text", nullable: false),
                    Monto_promesa = table.Column<double>(type: "double precision", nullable: false),
                    Fecha_Promesa = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoClientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoClientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActualidadClientes",
                table: "ActualidadClientes");

            migrationBuilder.RenameTable(
                name: "ActualidadClientes",
                newName: "ActualidadCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActualidadCliente",
                table: "ActualidadCliente",
                column: "id");
        }
    }
}
