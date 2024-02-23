using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Controllers;

namespace SETEC.Data.Entities
{
    public class ActualViewModelCheck
    {
        public List<ActualidadCliente> actualCliente { get; set; }
        public HistoricoClientesContrato historicoClientesContrato { get; set; }

       
    }
}