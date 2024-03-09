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
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;

namespace SETEC.Controllers
{
    [Authorize]
    public class ActualController : Controller
    {

        private readonly Appdbcontext _context;

        public ActualController(Appdbcontext context)
        {
            _context = context;
        }

        
        // GET: ActualController
        public async Task<ActionResult> Inforoute1(string search, string searchDate, string searchGestor)
        {
            Console.WriteLine($"Valor de Identidad: {search} Fecha: {searchDate} Gestor: {searchGestor}");
            var allactual = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente;
            var allactualDropDown = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente;
            var dropdownItems = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente.Identidad;
            var viewModel = new ActualViewModel();

            if (!String.IsNullOrEmpty(search) || !String.IsNullOrEmpty(searchDate) || !String.IsNullOrEmpty(searchGestor))
            {
                allactual = allactual.Where(s =>
                    (String.IsNullOrEmpty(search) || s.Identidad!.Contains(search)) &&
                    (String.IsNullOrEmpty(searchDate) || s.Fecha_Agenda == DateTime.Parse(searchDate)) &&
                    (String.IsNullOrEmpty(searchGestor) || s.Gestor == searchGestor)
                );

                dropdownItems = dropdownItems.Where(Identidad =>
                    (String.IsNullOrEmpty(search) || Identidad!.Contains(search)) &&
                    (String.IsNullOrEmpty(searchDate) || Identidad!.Contains(searchDate)) &&
                    (String.IsNullOrEmpty(searchGestor) || Identidad!.Contains(searchGestor))
                );
            }

            var actualClientesList = await allactual.ToListAsync();
            var codgestion = from Codgestion in _context.Mastergestion select Codgestion;
            var codGestionList = await codgestion.ToListAsync();

            viewModel = new ActualViewModel
            {
                ActualClientesList = actualClientesList,
                ActualClientesListDropDown = actualClientesList,
                Mastergestion = codGestionList,
                HistoricoClientesContrato = new HistoricoClientesContrato(),
            };

            return View(viewModel);
        }


        public IActionResult UploadActual()
        {
            var modelo = new ActualidadCliente(); // Crea una instancia del modelo
            return View(modelo);
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
        public IActionResult InsertarDatos(string datos, bool eliminar)
        {
            Console.WriteLine(datos);
            Console.WriteLine(eliminar);

            try
            {

            
            
            if (datos != null)

                {
                    if (eliminar == true)
                    {

                        _context.ActualidadClientes.RemoveRange(_context.ActualidadClientes);
                        _context.SaveChanges();

                    }

                    List<ActualidadCliente> actualidadClientes = JsonConvert.DeserializeObject<List<ActualidadCliente>>(datos);
                    Console.WriteLine(actualidadClientes);
                    _context.ActualidadClientes.AddRange(actualidadClientes);
                    _context.SaveChanges();


                    return RedirectToAction("UploadActual");

                }


                return RedirectToAction("Error");
            }
            catch (Exception)
            {

                throw;
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

