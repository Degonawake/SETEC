using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class changeFields2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agencia",
                table: "HistoricoClientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agencia",
                table: "HistoricoClientes");
        }
    }
}
