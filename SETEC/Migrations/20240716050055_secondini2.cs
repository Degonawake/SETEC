using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class secondini2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentario",
                table: "Verificacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Verificacion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Verificacion",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentario",
                table: "Verificacion");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Verificacion");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Verificacion");
        }
    }
}
