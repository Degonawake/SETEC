using Humanizer;
using Microsoft.AspNetCore.Authorization;
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
            var allactualDropDown = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente;
            var dropdownItems = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente.Identidad;
            var listado = _context.ActualidadClientes.Select(u => u.Identidad).ToList();
            var milista = _context.ActualidadClientes.Select(u => u.Identidad).ToList();
            var milista2 = _context.ActualidadClientes.Select(u => new { u.Identidad, u.Nombre
        }).ToList();
            var codgestion = from Codgestion in _context.Mastergestion select Codgestion;

            if (!String.IsNullOrEmpty(search))
            {
                allactual = allactual.Where(s => s.Identidad!.Contains(search));
                dropdownItems = dropdownItems.Where(Identidad => Identidad!.Contains(search));


            }
            var codGestionList = await codgestion.ToListAsync();
            var actualClientesList = await allactual.ToListAsync();
            var actualClientesDropDown = await allactualDropDown.ToListAsync();
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
                ActualClientesListDropDown = actualClientesDropDown,
                DropdownItems = dropdownItemsUnique,  
                milista = milista,
                
                Mastergestion = codGestionList,
                HistoricoClientesContrato = new HistoricoClientesContrato(),
            };
            return View(viewModel);
        }


        public IActionResult UploadActual()
        {
            var modelo = new ActualidadCliente(); // Crea una instancia del modelo
            return View(modelo);

            //return View();
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



        [HttpPost]
        public IActionResult InsertarDatos(string datos)
        {

            if (datos != null)
            {


                List<ActualidadCliente> actualidadClientes = JsonConvert.DeserializeObject<List<ActualidadCliente>>(datos);
                Console.WriteLine(actualidadClientes);
                _context.ActualidadClientes.AddRange(actualidadClientes);
                _context.SaveChanges();

                // Redirige a una vista de éxito o cualquier otra acción que desees
                return RedirectToAction("UploadActual");

            }

            // Datos es nulo, puedes manejarlo de acuerdo a tus requerimientos
            return RedirectToAction("Error");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

