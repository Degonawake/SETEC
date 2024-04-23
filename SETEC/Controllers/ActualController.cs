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
using System.Linq;

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
            ViewBag.Gestores = _context.ActualidadClientes.Select(c => c.Gestor).Distinct().ToList().OrderBy(c => c);
            ViewBag.FechaAgenda = _context.ActualidadClientes.Select(c => c.Fecha_Agenda).Distinct().ToList().OrderBy(c => c);
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
            try
            {
                // Verifica si hay datos para procesar
                if (!string.IsNullOrEmpty(datos))
                {
                    // Si se solicita eliminar los datos actuales
                    if (eliminar)
                    {
                        // Elimina todos los registros de ActualidadClientes
                        _context.ActualidadClientes.RemoveRange(_context.ActualidadClientes);
                        _context.SaveChanges(); // Guarda los cambios
                    }

                    // Deserializa los datos recibidos a una lista de ActualidadCliente
                    List<ActualidadCliente> actualidadClientes = JsonConvert.DeserializeObject<List<ActualidadCliente>>(datos);

                    // Asegúrate de verificar si la deserialización fue exitosa
                    if (actualidadClientes != null)
                    {
                        // Añade los nuevos registros a la base de datos
                        _context.ActualidadClientes.AddRange(actualidadClientes);
                        _context.SaveChanges(); // Guarda los cambios

                        // Redirige a la vista de UploadActual después de una operación exitosa
                        return RedirectToAction("UploadActual");
                    }
                }

                // Si no hay datos, redirige a una página de error o muestra un mensaje
                return RedirectToAction("Error");
            }
            catch (Exception ex)
            {
                // Puedes registrar el error para analizarlo más adelante
                Console.WriteLine($"Error al insertar datos: {ex.Message}");

                // Redirige a la página de error o muestra un mensaje de error
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

