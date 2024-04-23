using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Data.Entities;


namespace SETEC.Controllers
{
    [Authorize]
    public class AgendaClientesController : Controller
    {
        private readonly Appdbcontext _context;
        private List<Codgestion> codGestionList;

        public AgendaClientesController(Appdbcontext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index(string searchString, string searchStringAgente, string searchDateString)
        {
            // Inicializar la consulta para obtener todos los clientes
            var clientes = _context.ActualidadClientes.AsQueryable();

            // Filtrar por searchString
            if (!string.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(c => c.Nombre.Contains(searchString));
                ViewBag.SearchString = searchString;
            }

            // Filtrar por searchStringAgente (gestor) si se proporciona
            if (!string.IsNullOrEmpty(searchStringAgente))
            {
                clientes = clientes.Where(c => c.Gestor == searchStringAgente);
                ViewBag.SearchStringAgente = searchStringAgente;
            }

            // Filtrar por searchDateString
            if (DateTime.TryParse(searchDateString, out DateTime searchDate))
            {
                clientes = clientes.Where(c => c.Fecha_Agenda.Date == searchDate.Date);
                ViewBag.SearchDateString = searchDateString;
            }

            // Limitar los resultados a los primeros 1000 registros
            clientes = clientes.Take(1000);

            // Retornar la vista con los resultados filtrados y limitados
            return View(await clientes.ToListAsync());
        }


        // GET: AgendaClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.ActualidadClientes == null)
            {
                return NotFound();
            }




            var actualidadCliente = await _context.ActualidadClientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (actualidadCliente == null)
            {
                return NotFound();
            }

            var codgestion = from Codgestion in _context.Mastergestion select Codgestion;
            var codGestionList = await codgestion.ToListAsync();


            var viewModelCall = new ActualViewModelCall
            {

                actualCliente = actualidadCliente,
                masterGestion = codGestionList,
                HistoricoClientesContrato = new HistoricoClientesContrato(),
            };



            return View(viewModelCall);
        }

        // GET: AgendaClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgendaClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Gestor,Identidad,Nombre,Numero_telefono,Contrato,Antiguedad,Canal_de_venta,Articulos,Tipo_de_cartera,Dias_de_atraso,Monto_mensual_Factura,Saldo_total_credito,Saldo_en_Mora,Descuento,Pago_con_descuento,Vencimiento_factura,fecha_Agenda")] ActualidadCliente actualidadCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actualidadCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actualidadCliente);
        }

        // GET: AgendaClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActualidadClientes == null)
            {
                return NotFound();
            }

            var actualidadCliente = await _context.ActualidadClientes.FindAsync(id);
            if (actualidadCliente == null)
            {
                return NotFound();
            }
            return View(actualidadCliente);
        }

        // POST: AgendaClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Gestor,Identidad,Nombre,Numero_telefono,Contrato,Antiguedad,Canal_de_venta,Articulos,Tipo_de_cartera,Dias_de_atraso,Monto_mensual_Factura,Saldo_total_credito,Saldo_en_Mora,Descuento,Pago_con_descuento,Vencimiento_factura")] ActualidadCliente actualidadCliente)
        {
            if (id != actualidadCliente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actualidadCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActualidadClienteExists(actualidadCliente.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actualidadCliente);
        }

        // GET: AgendaClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActualidadClientes == null)
            {
                return NotFound();
            }

            var actualidadCliente = await _context.ActualidadClientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (actualidadCliente == null)
            {
                return NotFound();
            }

            return View(actualidadCliente);
        }

        // POST: AgendaClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActualidadClientes == null)
            {
                return Problem("Entity set 'Appdbcontext.ActualidadClientes'  is null.");
            }
            var actualidadCliente = await _context.ActualidadClientes.FindAsync(id);
            if (actualidadCliente != null)
            {
                _context.ActualidadClientes.Remove(actualidadCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActualidadClienteExists(int id)
        {
            return (_context.ActualidadClientes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
