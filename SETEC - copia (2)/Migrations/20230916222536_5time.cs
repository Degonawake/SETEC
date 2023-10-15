using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    public partial class _5time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
