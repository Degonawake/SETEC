using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class changeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Agente",
                table: "HistoricoClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cartera",
                table: "HistoricoClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Descuento",
                table: "HistoricoClientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Gestor",
                table: "HistoricoClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Saldo_Total",
                table: "HistoricoClientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Saldo_mora",
                table: "HistoricoClientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Ingreso",
                table: "HistoricoClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agencia",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cartera",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consolidado_BD",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion_Empresa_Labor",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Empresa_Labor",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gen1",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gen2",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gen3",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tel_Empresa_Labor",
                table: "ActualidadClientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agente",
                table: "HistoricoClientes");

            migrationBuilder.DropColumn(
                name: "Cartera",
                table: "HistoricoClientes");

            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "HistoricoClientes");

            migrationBuilder.DropColumn(
                name: "Gestor",
                table: "HistoricoClientes");

            migrationBuilder.DropColumn(
                name: "Saldo_Total",
                table: "HistoricoClientes");

            migrationBuilder.DropColumn(
                name: "Saldo_mora",
                table: "HistoricoClientes");

            migrationBuilder.DropColumn(
                name: "Tipo_Ingreso",
                table: "HistoricoClientes");

            migrationBuilder.DropColumn(
                name: "Agencia",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Cartera",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Consolidado_BD",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Direccion_Empresa_Labor",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Empresa_Labor",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Gen1",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Gen2",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Gen3",
                table: "ActualidadClientes");

            migrationBuilder.DropColumn(
                name: "Tel_Empresa_Labor",
                table: "ActualidadClientes");
        }
    }
}
