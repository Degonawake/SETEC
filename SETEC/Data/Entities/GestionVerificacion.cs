using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System;
using System.Globalization;
using System.ComponentModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SETEC.Data.Entities
{
    public class GestionVerificacion
    {
        public int id { get; set; }

        public int CodigoGestion { get; set; }
        public string? StatusGestion { get; set; }


    }

}
