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
    public class AgendaClientesController : Controller
    {
        private readonly Appdbcontext _context;
        private List<Codgestion> codGestionList;

        public AgendaClientesController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: AgendaClientes
        public async Task<IActionResult> Index()
        {

            var actualidadClientesConGestion = _context.ActualidadClientes
    .Select(ac => new
    {
        ActualidadCliente = ac,
        Gestionado = _context.HistoricoClientes
            .Any(h =>
                h.Fecha_Agenda == ac.Fecha_Agenda &&
                h.Identidad == ac.Identidad &&
                h.Contrato == ac.Contrato)
    })
    .ToList();
           
            var actualidadClientes = actualidadClientesConGestion
                .Select(acg => new ActualidadCliente
                {      
                    id = acg.ActualidadCliente.id,
                    Gestor = acg.ActualidadCliente.Gestor,
                    Identidad = acg.ActualidadCliente.Identidad,
                    Nombre = acg.ActualidadCliente.Nombre,
                    Gestionado = acg.Gestionado,
                    Numero_telefono = acg.ActualidadCliente.Identidad,
                    Contrato = acg.ActualidadCliente.Contrato,
                    Antiguedad = acg.ActualidadCliente.Antiguedad,
                    Canal_de_venta = acg.ActualidadCliente.Canal_de_venta,
                    Articulos = acg.ActualidadCliente.Articulos,
                    Tipo_de_cartera = acg.ActualidadCliente.Tipo_de_cartera,
                    Dias_de_atraso = acg.ActualidadCliente.Dias_de_atraso,
                    Monto_mensual_Factura = acg.ActualidadCliente.Monto_mensual_Factura,
                    Saldo_total_credito = acg.ActualidadCliente.Saldo_total_credito,
                    Saldo_en_Mora = acg.ActualidadCliente.Saldo_en_Mora,
                    Descuento = acg.ActualidadCliente.Descuento,
                    Pago_con_descuento = acg.ActualidadCliente.Pago_con_descuento,
                    Vencimiento_factura = acg.ActualidadCliente.Vencimiento_factura,
                    Fecha_Agenda = acg.ActualidadCliente.Fecha_Agenda                  
    })
                .ToList().OrderBy(ac => ac.id);
            return _context.ActualidadClientes != null ?
                              View(actualidadClientes) :
                              Problem("Entity set 'Appdbcontext.ActualidadClientes'  is null.");
}



public async Task<IActionResult> IndexSearch(string searchString)
{

    var clientes = _context.ActualidadClientes.AsQueryable();
    if (!string.IsNullOrEmpty(searchString))
    {
        clientes = clientes.Where(c => c.Nombre.Contains(searchString));
        return View("Index", await clientes.ToListAsync());
    }

    return _context.ActualidadClientes != null ?
                 View("Index", await _context.ActualidadClientes.ToListAsync()) :
                 Problem("Entity set 'Appdbcontext.ActualidadClientes'  is null.");
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
