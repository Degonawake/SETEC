using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SETEC.Migrations
{
    /// <inheritdoc />
    public partial class secondini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verificacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(name: "Fecha_Creacion", type: "datetime2", nullable: false),
                    FechaVerificacion = table.Column<DateTime>(name: "Fecha_Verificacion", type: "datetime2", nullable: false),
                    EmpresaVerificacion = table.Column<string>(name: "Empresa_Verificacion", type: "nvarchar(max)", nullable: true),
                    Identidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCliente = table.Column<string>(name: "Nombre_Cliente", type: "nvarchar(max)", nullable: true),
                    Tienda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelEmpresaLabor = table.Column<string>(name: "Tel_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    EmpresaLabor = table.Column<string>(name: "Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    ColoniaEmpresaLabor = table.Column<string>(name: "Colonia_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    BloqueEmpresaLabor = table.Column<string>(name: "Bloque_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    PeatonalEmpresaLabor = table.Column<string>(name: "Peatonal_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    ZonaEtapaEmpresaLabor = table.Column<string>(name: "ZonaEtapa_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    CalleEmpresaLabor = table.Column<string>(name: "Calle_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    AveEmpresaLabor = table.Column<string>(name: "Ave_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    SectorEmpresaLabor = table.Column<string>(name: "Sector_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    CasaEmpresaLabor = table.Column<string>(name: "Casa_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    Planta1EmpresaLabor = table.Column<bool>(name: "Planta1_Empresa_Labor", type: "bit", nullable: false),
                    Planta2EmpresaLabor = table.Column<bool>(name: "Planta2_Empresa_Labor", type: "bit", nullable: false),
                    EdificioEmpresaLabor = table.Column<bool>(name: "Edificio_Empresa_Labor", type: "bit", nullable: false),
                    ColorEmpresaLabor = table.Column<string>(name: "Color_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    SucursalEmpresaLabor = table.Column<bool>(name: "Sucursal_Empresa_Labor", type: "bit", nullable: false),
                    DireccionSucursalEmpresaLabor = table.Column<string>(name: "DireccionSucursal_Empresa_Labor", type: "nvarchar(max)", nullable: true),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoLocalActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoLocalAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColoniaLocalAnterior = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermisoOperacion = table.Column<bool>(type: "bit", nullable: false),
                    FotografiaPermisoOperacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CotizaRap = table.Column<bool>(type: "bit", nullable: false),
                    CotizaIHSS = table.Column<bool>(type: "bit", nullable: false),
                    CotizaINJUPEMP = table.Column<bool>(type: "bit", nullable: false),
                    FormadePago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TamEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RubroEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngresoMensual = table.Column<double>(type: "float", nullable: false),
                    HorasExtras = table.Column<bool>(type: "bit", nullable: false),
                    Promedio = table.Column<double>(type: "float", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JefeInmediato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoRRHH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaConfirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuestoPersonaConfirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoviemientoClientes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobiliario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estacionamiento = table.Column<bool>(type: "bit", nullable: false),
                    FotoEstacionamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusConformacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazonNoConfirmacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeSugiereNuevaVisita = table.Column<bool>(type: "bit", nullable: false),
                    RazonNuevaVisita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SePudoRealizar = table.Column<bool>(type: "bit", nullable: false),
                    RazonNoRealizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dictamen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gestor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UbicacionGPS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificacion", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verificacion");
        }
    }
}
