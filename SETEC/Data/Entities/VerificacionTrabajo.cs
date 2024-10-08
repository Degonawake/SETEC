using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System;
using System.Globalization;
using System.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SETEC.Data.Entities
{
    public class VerificacionTrabajo
    {
        public int id { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Verificacion { get; set; }
        public string? Empresa_Verificacion { get; set; }
        public string? Identidad { get; set; }
        public string? Nombre_Cliente { get; set; }
        public string? ComentarioAgenda { get; set; }
        public string? Gestor { get; set; }
        public string? Numero_telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Canal_de_venta { get; set; }
        public string? Estado_Verificacion { get; set; }
        public string? TipoGestion { get; set; }
        public string? Tel_Empresa_Labor { get; set; }
        public string? Empresa_Labor { get; set; }
        public string? Direccion_Empresa_Labor { get; set; }
        public string? ComentarioVerificacion { get; set; }
        public string? UbicacionGPS { get; set; }

    }

}
