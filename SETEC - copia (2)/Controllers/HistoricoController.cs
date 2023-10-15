using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Data.Entities;

namespace SETEC.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly Appdbcontext _context;

        public HistoricoController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: Historico
        public async Task<IActionResult> Index(string buscaridentidad)
        {
           
            var identidad = from HistoricoClientesContrato in _context.HistoricoClientes select HistoricoClientesContrato;


            if (!String.IsNullOrEmpty(buscaridentidad))
            {
                identidad = identidad.Where(s => s.Identidad!.Contains(buscaridentidad));
            }
         

            Console.WriteLine("Buscar Identidad: " + buscaridentidad);

            return View(await identidad.ToListAsync());


            
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
        public async Task<IActionResult> Create([Bind("Id,Fechagestion,Identidad,Nombre,Contrato,Codigo_Gestion,Desc_gestion,Monto_promesa,Fecha_Promesa")] HistoricoClientesContrato historicoClientesContrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicoClientesContrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fechagestion,Identidad,Nombre,Contrato,Codigo_Gestion,Desc_gestion,Monto_promesa,Fecha_Promesa")] HistoricoClientesContrato historicoClientesContrato)
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
