using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SETEC.Data.Entities;
using SETEC.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;



namespace SETEC.Controllers
{
    public class ActualController : Controller
    {

        private readonly Appdbcontext _context;
        
        public ActualController(Appdbcontext context)
        {
            _context = context;
        }


        // GET: ActualController
        public async Task<ActionResult> Inforoute1(string search)
            {
                var viewModel = new ActualViewModel();
                var allactual = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente;
                var dropdownItems = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente.Identidad;
                var listado = _context.ActualidadClientes.Select(u => u.Identidad).ToList();
                var milista = _context.ActualidadClientes.Select(u => u.Identidad).ToList();
                var codgestion = from Codgestion in _context.Mastergestion select Codgestion;

            if (!String.IsNullOrEmpty(search))
             {
                allactual = allactual.Where(s => s.Identidad!.Contains(search));
                dropdownItems = dropdownItems.Where(Identidad => Identidad!.Contains(search));

             
            }
            var codGestionList = await codgestion.ToListAsync();
            var actualClientesList = await allactual.ToListAsync();
            var dropdownItemsUnique = await dropdownItems
            .Distinct()
            .Select(Identidad => new SelectListItem
            {
                Value = Identidad,
                Text = Identidad
            }).ToListAsync();

            

            viewModel = new ActualViewModel
            {
                ActualClientesList = actualClientesList,
                DropdownItems = dropdownItemsUnique,
                milista = milista,
                Mastergestion = codGestionList,
                HistoricoClientesContrato = new HistoricoClientesContrato(),
            };
                return View(viewModel);
        }


        public IActionResult UploadActual()
        {
           
            return View();
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

        public IActionResult Error()
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult SubirATabla(string datos)
        {
            _context.ActualidadClientes.AddRange(data);
            _context.SaveChanges();

            return View("UploadActual");

        }

    }

}

