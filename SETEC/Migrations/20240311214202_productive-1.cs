using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class productive1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agente",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado_Gest",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoGestion",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agente",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Estado_Gest",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "TipoGestion",
                table: "ActualidadClientes");
        }
    }
}
