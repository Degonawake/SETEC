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
    public class CodgestionsController : Controller
    {
        private readonly Appdbcontext _context; 

        public CodgestionsController(Appdbcontext context)
        {
            _context = context;
        }

        
        // GET: Codgestions
        public async Task<IActionResult> Indexgestioncodes()
        {
           var listadoscode = new List<String>();
           listadoscode= _context.Mastergestion.Select(u => u.idgestion).ToList();
            return _context.Mastergestion != null ? 
                          View(await _context.Mastergestion.ToListAsync()) :
                          Problem("Entity set 'Appdbcontext.Mastergestion'  is null.");

        }

        // GET: Codgestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mastergestion == null)
            {
                return NotFound();
            }

            var codgestion = await _context.Mastergestion
                .FirstOrDefaultAsync(m => m.id == id);
            if (codgestion == null)
            {
                return NotFound();
            }

            return View(codgestion);
        }

        // GET: Codgestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Codgestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,idgestion,DescGestion")] Codgestion codgestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codgestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Indexgestioncodes));
            }
            return View(codgestion);
        }

        // GET: Codgestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mastergestion == null)
            {
                return NotFound();
            }

            var codgestion = await _context.Mastergestion.FindAsync(id);
            if (codgestion == null)
            {
                return NotFound();
            }
            return View(codgestion);
        }

        // POST: Codgestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,idgestion,DescGestion")] Codgestion codgestion)
        {
            if (id != codgestion.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codgestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodgestionExists(codgestion.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Indexgestioncodes));
            }
            return View(codgestion);
        }

        // GET: Codgestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mastergestion == null)
            {
                return NotFound();
            }

            var codgestion = await _context.Mastergestion
                .FirstOrDefaultAsync(m => m.id == id);
            if (codgestion == null)
            {
                return NotFound();
            }

            return View(codgestion);
        }

        // POST: Codgestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mastergestion == null)
            {
                return Problem("Entity set 'Appdbcontext.Mastergestion'  is null.");
            }
            var codgestion = await _context.Mastergestion.FindAsync(id);
            if (codgestion != null)
            {
                _context.Mastergestion.Remove(codgestion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Indexgestioncodes));
        }

        private bool CodgestionExists(int id)
        {
          return (_context.Mastergestion?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
