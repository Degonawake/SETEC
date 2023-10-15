using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Controllers;

namespace SETEC.Data.Entities
{
    public class ActualViewModel
    {
        public List<ActualidadCliente> ActualClientesList { get; set; }
        public List<Codgestion> Mastergestion { get; set; }
        public List<SelectListItem> DropdownItems { get; set; }
        public List<String> milista  { get; set; }
        public List<String> Codgestionlist { get; set; }

        public HistoricoClientesContrato HistoricoClientesContrato { get; set; }

        public HistoricoController historicoController { get; set; }
    }
}