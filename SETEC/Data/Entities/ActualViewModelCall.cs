using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Controllers;

namespace SETEC.Data.Entities
{
    public class ActualViewModelCall
    {
        public ActualidadCliente actualCliente { get; set; }
        
        public List<Codgestion> masterGestion { get; set; }
    
        public List<string> codgestionList { get; set; }

        public HistoricoClientesContrato HistoricoClientesContrato { get; set; }

        public HistoricoController historicoController { get; set; }
    }
}