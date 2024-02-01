using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    public partial class nuevo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "latitud",
                table: "HistoricoClientes",
                newName: "Latitud");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Latitud",
                table: "HistoricoClientes",
                newName: "latitud");
        }
    }
}
