using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class secondini3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Sucursal_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "SeSugiereNuevaVisita",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "SePudoRealizar",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "Promedio",
                table: "Verificacion",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "Planta2_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Planta1_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "PermisoOperacion",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<double>(
                name: "IngresoMensual",
                table: "Verificacion",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<bool>(
                name: "HorasExtras",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "Verificacion",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Estacionamiento",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Edificio_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "CotizaRap",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "CotizaINJUPEMP",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "CotizaIHSS",
                table: "Verificacion",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Sucursal_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SeSugiereNuevaVisita",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SePudoRealizar",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Promedio",
                table: "Verificacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Planta2_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Planta1_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PermisoOperacion",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "IngresoMensual",
                table: "Verificacion",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HorasExtras",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "Verificacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Estacionamiento",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Edificio_Empresa_Labor",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CotizaRap",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CotizaINJUPEMP",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CotizaIHSS",
                table: "Verificacion",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
