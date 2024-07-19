using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System;
using System.Globalization;
using System.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SETEC.Data.Entities
{
    public class Verificacion
    {
        public int id { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Verificacion { get; set; }
        public string? Empresa_Verificacion { get; set; }
        public string? Identidad { get; set; }
        public string? Nombre_Cliente { get; set; }
        public string? Tienda { get; set; }
        public string? Tel_Empresa_Labor { get; set; }
        public string? Empresa_Labor { get; set; }
        public string? Colonia_Empresa_Labor { get; set; }

        public string? Bloque_Empresa_Labor { get; set; }

        public string? Peatonal_Empresa_Labor { get; set; }

        public string? ZonaEtapa_Empresa_Labor { get; set; }

        public string? Calle_Empresa_Labor { get; set; }

        public string? Ave_Empresa_Labor { get; set; }

        public string? Sector_Empresa_Labor { get; set; }

        public string? Casa_Empresa_Labor { get; set; }

        public bool? Planta1_Empresa_Labor { get; set; }

        public bool? Planta2_Empresa_Labor { get; set; }

        public bool? Edificio_Empresa_Labor { get; set; }

        public string? Color_Empresa_Labor { get; set; }

        public bool? Sucursal_Empresa_Labor { get; set; }

        public string? DireccionSucursal_Empresa_Labor { get; set; }

        public string? Local { get; set; }

        public string? TiempoLocal { get; set; }

        public string? TiempoLocalActual { get; set; }

        public string? TiempoLocalAnterior { get; set; }

        public string? ColoniaLocalAnterior { get; set; }

        public string? ClienteEmpresa { get; set; }

        public bool? PermisoOperacion { get; set; }

        public string? FotografiaPermisoOperacion { get; set; }

        public bool? CotizaRap { get; set; }

        public bool? CotizaIHSS { get; set; }

        public bool? CotizaINJUPEMP { get; set; }

        public string? FormadePago { get; set; }

        public string? TamEmpresa { get; set; }

        public string? RubroEmpresa { get; set; }

        public double? IngresoMensual { get; set; }

        public bool? HorasExtras { get; set; }

        public double? Promedio { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string? Puesto { get; set; }

        public string? Depto { get; set; }

        public string? JefeInmediato { get; set; }

        public string? HorarioTrabajo { get; set; }

        public string? TelefonoCliente { get; set; }

        public string? TelefonoRRHH { get; set; }

        public string? PersonaConfirma { get; set; }

        public string? PuestoPersonaConfirma { get; set; }

        public string? MoviemientoClientes { get; set; }

        public string? Mobiliario { get; set; }

        public bool? Estacionamiento { get; set; }

        public string? FotoEstacionamiento { get; set; }

        public string? StatusConformacion { get; set; }

        public string? RazonNoConfirmacion { get; set; }

        public bool? SeSugiereNuevaVisita { get; set; }

        public string? RazonNuevaVisita { get; set; }

        public bool? SePudoRealizar { get; set; }

        public string? RazonNoRealizacion { get; set; }

        public string? Dictamen { get; set; }

        public string? Gestor { get; set; }

        public string? UbicacionGPS { get; set; }

        public string? Status { get; set; }

        public string? Comentario { get; set; }

        public string? Usuario { get; set; }


        public string? Archivo { get; set; }


    }

}
