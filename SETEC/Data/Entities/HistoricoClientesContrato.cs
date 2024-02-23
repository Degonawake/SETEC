using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SETEC.Data.Entities
{
    public class HistoricoClientesContrato
    {
        public int Id { get; set; }
        public DateTime Fechagestion { get; set; }
        public DateTime Fecha_Agenda { get; set; }
        public string? Identidad { get; set; }
        public string? Nombre { get; set; }
        public string? Contrato { get; set; }

        [Required(ErrorMessage = "El campo Descripcion de la gestion es obligatorio.")]
        public string? Codigo_Gestion { get; set; }

        [Required(ErrorMessage = "El campo Descripcion de la gestion es obligatorio.")]
        public string? Desc_gestion { get; set; }
        public double Monto_promesa { get; set; }
        public DateTime Fecha_Promesa { get; set; }

        public DateTime Fecha_NuevaVisita { get; set; }

        public string? Comentario { get; set; }
        public string? Latitud { get; set; }

    }
}
