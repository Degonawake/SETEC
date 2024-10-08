using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class secondini4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Archivo",
                table: "Verificacion",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archivo",
                table: "Verificacion");
        }
    }
}
