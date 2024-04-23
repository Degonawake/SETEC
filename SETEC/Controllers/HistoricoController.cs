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
    public class HistoricoController : Controller
    {
        private readonly Appdbcontext _context;

        public HistoricoController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index(string buscaridentidad, string agencia, string nombre, string mesAnio)
        {
            IQueryable<HistoricoClientesContrato> query = _context.HistoricoClientes.OrderByDescending(g => g.Fechagestion);

            // Filtro por identidad
            Console.WriteLine(agencia);
            Console.WriteLine(nombre);
            Console.WriteLine(mesAnio);
            
            // Filtro por agencia
            if (!string.IsNullOrEmpty(agencia))
            {
                query = query.Where(h => h.Agencia.Contains(agencia));
            }

            // Filtro por nombre
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(h => h.Nombre.Contains(nombre));
            }

            // Filtro por mes y año combinados
            if (!string.IsNullOrEmpty(mesAnio))
            {
                var split = mesAnio.Split('-');
                int mes = int.Parse(split[0]);
                int anio = int.Parse(split[1]);

                query = query.Where(h => h.Fechagestion.Month == mes && h.Fechagestion.Year == anio);
            }

            // Obtener la lista de agencias distintas de la base de datos
            var agencias = await _context.HistoricoClientes
                .Select(h => h.Agencia)
                .Distinct()
                .ToListAsync();

            // Asignar la lista de agencias a ViewBag
            ViewBag.Agencias = new SelectList(agencias);

            // Obtener la lista de combinaciones de mes y año distintas
            var mesesAnios = await _context.HistoricoClientes
                .GroupBy(h => new { h.Fechagestion.Month, h.Fechagestion.Year })
                .Select(g => new {
                    Value = $"{g.Key.Month}-{g.Key.Year}",
                    Text = $"{new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMMM yyyy")}"
                })
                .Distinct()
                .ToListAsync();

  
            ViewBag.MesesAnios = new SelectList(mesesAnios, "Value", "Text");

            // Obtener los datos filtrados
            var historicoClientes = await query.ToListAsync();

        
            return View(historicoClientes);
        }


        // GET: Historico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoricoClientes == null)
            {
                return NotFound();
            }

            var historicoClientesContrato = await _context.HistoricoClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoClientesContrato == null)
            {
                return NotFound();
            }

            return View(historicoClientesContrato);
        }


        public async Task<IActionResult> Estadisticas(int? mes, int? año, string nombre)
        {
            IQueryable<HistoricoClientesContrato> query = _context.HistoricoClientes;

            if (mes.HasValue)
            {
                query = query.Where(h => h.Fechagestion.Month == mes);
            }

            if (año.HasValue)
            {
                query = query.Where(h => h.Fechagestion.Year == año);
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(h => h.Nombre.Contains(nombre));
            }

            var historicoClientes = await query.ToListAsync();

            // Obtener la cantidad de gestiones por día
            var cantidadGestionesPorDia = historicoClientes
                .GroupBy(h => h.Fecha_Agenda.Date)
                .Select(g => new { Dia = g.Key.ToString("yyyy-MM-dd"), Cantidad = g.Count() })
                .OrderBy(x => x.Dia)
                .ToList();

            // Obtener la cantidad de clientes por código de gestión
            var cantidadClientesPorCodigoGestion = historicoClientes
                .GroupBy(h => h.Codigo_Gestion)
                .Select(g => new { Codigo = g.Key, Cantidad = g.Count() })
                .ToList();

            var sumaGestionespordia = historicoClientes
            .GroupBy(h => h.Fecha_Agenda.Date)
            .Select(g => new
            {
                Dia = g.Key.ToString("yyyy-MM-dd"),
                Cantidad = g.Sum(h => h.Monto_promesa)
            })
            .OrderBy(x => x.Dia)
            .ToList();

            ViewBag.CantidadGestionesPorDia = cantidadGestionesPorDia;
            ViewBag.CantidadClientesPorCodigoGestion = cantidadClientesPorCodigoGestion;
            ViewBag.sumaGestionespordia = sumaGestionespordia;

            return View(historicoClientes);
        }


        // GET: Historico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fechagestion,Tipo_Ingreso,Identidad,Nombre,Contrato,Codigo_Gestion,Desc_gestion,Monto_promesa,Saldo_mora,Saldo_Total,Descuento,Gestor,Agente,Agencia,Fecha_Promesa,Fecha_NuevaVisita,Comentario,Latitud,Fecha_Agenda")] HistoricoClientesContrato historicoClientesContrato, string tipoIngreso)
        {


            if (ModelState.IsValid)
            {

                _context.Add(historicoClientesContrato);
                await _context.SaveChangesAsync();

                var actualCliente = await _context.ActualidadClientes.FirstOrDefaultAsync(c => c.Identidad == historicoClientesContrato.Identidad && c.Contrato == historicoClientesContrato.Contrato && c.Fecha_Agenda == historicoClientesContrato.Fecha_Agenda);
                var actualClienteIngreso = _context.ActualidadClientes.FirstOrDefault(c => c.Identidad == historicoClientesContrato.Identidad && c.Contrato == historicoClientesContrato.Contrato);
                if (actualCliente != null)
                {
                    Console.WriteLine(actualCliente.Identidad?.ToString());
                    Console.WriteLine(historicoClientesContrato.Identidad?.ToString());
                    Console.WriteLine(actualCliente.Contrato);
                    Console.WriteLine(historicoClientesContrato.Contrato);
                    Console.WriteLine(actualCliente.Fecha_Agenda);
                    Console.WriteLine(historicoClientesContrato.Fecha_Agenda);
                    Console.WriteLine(historicoClientesContrato.Tipo_Ingreso);

                    actualCliente.Estado_Gest = historicoClientesContrato.Codigo_Gestion;
                    actualCliente.Gestionado = true;
                    _context.Update(actualCliente);

                    await _context.SaveChangesAsync();
                    Console.WriteLine("Se guardaron los cambios");

                    actualClienteIngreso.Fecha_Agenda = historicoClientesContrato.Fecha_NuevaVisita;
                    actualClienteIngreso.id = 0;
                    actualClienteIngreso.Estado_Gest = "";
                    actualClienteIngreso.Gestionado = false;


                    _context.Add(actualClienteIngreso);
                    await _context.SaveChangesAsync();

                }


                if (tipoIngreso == "Visita")
                {
                    return RedirectToAction("Inforoute1", "Actual");
                }
                else
                {
                    return RedirectToAction("Index", "AgendaClientes");
                }
            }
            return View(historicoClientesContrato);
        }

        // GET: Historico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistoricoClientes == null)
            {
                return NotFound();
            }

            var historicoClientesContrato = await _context.HistoricoClientes.FindAsync(id);
            if (historicoClientesContrato == null)
            {
                return NotFound();
            }
            return View(historicoClientesContrato);
        }

        // POST: Historico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fechagestion,Identidad,Nombre,Contrato,Codigo_Gestion,Desc_gestion,Monto_promesa,Comentario,Fecha_Promesa")] HistoricoClientesContrato historicoClientesContrato)
        {
            if (id != historicoClientesContrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoClientesContrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoClientesContratoExists(historicoClientesContrato.Id))
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
            return View(historicoClientesContrato);
        }

        // GET: Historico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoricoClientes == null)
            {
                return NotFound();
            }

            var historicoClientesContrato = await _context.HistoricoClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoClientesContrato == null)
            {
                return NotFound();
            }

            return View(historicoClientesContrato);
        }

        // POST: Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoricoClientes == null)
            {
                return Problem("Entity set 'Appdbcontext.HistoricoClientes'  is null.");
            }
            var historicoClientesContrato = await _context.HistoricoClientes.FindAsync(id);
            if (historicoClientesContrato != null)
            {
                _context.HistoricoClientes.Remove(historicoClientesContrato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoClientesContratoExists(int id)
        {
            return (_context.HistoricoClientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
