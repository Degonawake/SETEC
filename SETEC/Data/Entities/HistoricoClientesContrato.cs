using Microsoft.EntityFrameworkCore;

namespace SETEC.Data.Entities
{
    public class HistoricoClientesContrato
    {
        public int Id { get; set; }
        public DateTime Fechagestion { get; set; }
        public string Identidad { get; set; }
        public string Nombre { get; set; }
       public string Contrato { get; set; }
       
        public string Codigo_Gestion { get; set; }
        public string Desc_gestion { get; set; }
        public double Monto_promesa { get; set; }
        public DateTime Fecha_Promesa { get; set; }
        public string? Latitud { get; set; }
     
    }
}
