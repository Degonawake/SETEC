using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Data.Entities;

namespace SETEC.Controllers
{
    public class ActualController : Controller
    {

        private readonly Appdbcontext _context;

        public ActualController(Appdbcontext context)
        {
            _context = context;
        }

        /*public CodgestionsController(Appdbcontext context2)
        {
            _context2 = context2;
        }*/

        // GET: ActualController
        public async Task<ActionResult> Inforoute1(string search)
            {
                var allactual = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente;
                var dropdownItems = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente.Identidad;
                var listado = _context.ActualidadClientes.Select(u => u.Identidad).ToList();
                var milista = _context.ActualidadClientes.Select(u => u.Identidad).ToList();
                var codgestion = _context.Mastergestion.Select(u => u.idgestion).ToList();
            //ViewBag.listado = listado;           
            
            //var actualclients = await _context.ActualidadClientes.ToListAsync();
            if (!String.IsNullOrEmpty(search))
                {
                        allactual = allactual.Where(s => s.Identidad!.Contains(search));
                        dropdownItems = dropdownItems.Where(Identidad => Identidad!.Contains(search));
                }

                var actualClientesList = await allactual.ToListAsync();
                var dropdownItemsUnique = await dropdownItems
                .Distinct()
                .Select(Identidad => new SelectListItem
                {
                    Value = Identidad,
                    Text = Identidad
                }).ToListAsync();






            var viewModel = new ActualViewModel
            {
                ActualClientesList = actualClientesList,
                DropdownItems = dropdownItemsUnique,
                milista = milista,
                Codgestionlist = codgestion,
                HistoricoClientesContrato = new HistoricoClientesContrato(),
               
            };



            return View(viewModel);
        }

        public async Task<IActionResult> Actualidad(string buscaridentidad)
        {

            var allactual = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente;


            if (!String.IsNullOrEmpty(buscaridentidad))
            {
                allactual = allactual.Where(s => s.Identidad!.Contains(buscaridentidad));
            }


            return View(await allactual.ToListAsync());
            
        }



    }
}
