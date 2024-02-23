using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System;
using System.Globalization;
using System.ComponentModel;
using Newtonsoft.Json;
namespace SETEC.Data.Entities
{
    public class ActualidadCliente
    {
        public int id { get; set; }
        public string? Gestor { get; set; }
        public string? Identidad { get; set; }
        public string? Nombre { get; set; }
        public string? Numero_telefono { get; set; }
        public string? Contrato { get; set; }
        public string? Antiguedad { get; set; }
        public string? Canal_de_venta { get; set; }
        public string? Articulos { get; set; }
        public string? Tipo_de_cartera { get; set; }
        public int Dias_de_atraso { get; set; }
        public double Monto_mensual_Factura { get; set; }
        public double Saldo_total_credito { get; set; }
        public double Saldo_en_Mora { get; set; }
        public double Descuento { get; set; }
        public double Pago_con_descuento { get; set; }
        public DateTime Vencimiento_factura { get; set; }
        public DateTime Fecha_Agenda { get; set; }
        public bool Gestionado { get; set; }

    }

}
