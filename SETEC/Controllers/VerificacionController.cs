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
    public class VerificacionController : Controller
    {
        private readonly Appdbcontext _context;

        public VerificacionController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: Verificacion
        public async Task<IActionResult> Index()
        {
              return _context.Verificacion != null ? 
                          View(await _context.Verificacion.ToListAsync()) :
                          Problem("Entity set 'Appdbcontext.Verificacion'  is null.");
        }


        // GET: Verificacion
        public async Task<IActionResult> IndexAsignacion()
        {
            return _context.Verificacion != null ?
                        View(await _context.Verificacion.ToListAsync()) :
                        Problem("Entity set 'Appdbcontext.Verificacion'  is null.");
        }

        // GET: Verificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Verificacion == null)
            {
                return NotFound();
            }

            var verificacion = await _context.Verificacion
                .FirstOrDefaultAsync(m => m.id == id);
            if (verificacion == null)
            {
                return NotFound();
            }

            return View(verificacion);
        }

        // GET: Verificacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion,Identidad,Nombre_Cliente,Tienda,Tel_Empresa_Labor,Empresa_Labor,Colonia_Empresa_Labor,Bloque_Empresa_Labor,Peatonal_Empresa_Labor,ZonaEtapa_Empresa_Labor,Calle_Empresa_Labor,Ave_Empresa_Labor,Sector_Empresa_Labor,Casa_Empresa_Labor,Planta1_Empresa_Labor,Planta2_Empresa_Labor,Edificio_Empresa_Labor,Color_Empresa_Labor,Sucursal_Empresa_Labor,DireccionSucursal_Empresa_Labor,Local,TiempoLocal,TiempoLocalActual,TiempoLocalAnterior,ColoniaLocalAnterior,ClienteEmpresa,PermisoOperacion,FotografiaPermisoOperacion,CotizaRap,CotizaIHSS,CotizaINJUPEMP,FormadePago,TamEmpresa,RubroEmpresa,IngresoMensual,HorasExtras,Promedio,FechaIngreso,Puesto,Depto,JefeInmediato,HorarioTrabajo,TelefonoCliente,TelefonoRRHH,PersonaConfirma,PuestoPersonaConfirma,MoviemientoClientes,Mobiliario,Estacionamiento,FotoEstacionamiento,StatusConformacion,RazonNoConfirmacion,SeSugiereNuevaVisita,RazonNuevaVisita,SePudoRealizar,RazonNoRealizacion,Dictamen,Gestor,UbicacionGPS,Status, Comentario")] Verificacion verificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verificacion);
        }

        // GET: Verificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Verificacion == null)
            {
                return NotFound();
            }

            var verificacion = await _context.Verificacion.FindAsync(id);
            if (verificacion == null)
            {
                return NotFound();
            }
            return View(verificacion);
        }

        public async Task<IActionResult> EditarAsignacion(int? id)
        {
            if (id == null || _context.Verificacion == null)
            {
                return NotFound();
            }

            var verificacion = await _context.Verificacion.FindAsync(id);
            if (verificacion == null)
            {
                return NotFound();
            }
            return View(verificacion);
        }

        // POST: Verificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion,Identidad,Nombre_Cliente,Tienda,Tel_Empresa_Labor,Empresa_Labor,Colonia_Empresa_Labor,Bloque_Empresa_Labor,Peatonal_Empresa_Labor,ZonaEtapa_Empresa_Labor,Calle_Empresa_Labor,Ave_Empresa_Labor,Sector_Empresa_Labor,Casa_Empresa_Labor,Planta1_Empresa_Labor,Planta2_Empresa_Labor,Edificio_Empresa_Labor,Color_Empresa_Labor,Sucursal_Empresa_Labor,DireccionSucursal_Empresa_Labor,Local,TiempoLocal,TiempoLocalActual,TiempoLocalAnterior,ColoniaLocalAnterior,ClienteEmpresa,PermisoOperacion,FotografiaPermisoOperacion,CotizaRap,CotizaIHSS,CotizaINJUPEMP,FormadePago,TamEmpresa,RubroEmpresa,IngresoMensual,HorasExtras,Promedio,FechaIngreso,Puesto,Depto,JefeInmediato,HorarioTrabajo,TelefonoCliente,TelefonoRRHH,PersonaConfirma,PuestoPersonaConfirma,MoviemientoClientes,Mobiliario,Estacionamiento,FotoEstacionamiento,StatusConformacion,RazonNoConfirmacion,SeSugiereNuevaVisita,RazonNuevaVisita,SePudoRealizar,RazonNoRealizacion,Dictamen,Gestor,UbicacionGPS")] Verificacion verificacion)
        {
            if (id != verificacion.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerificacionExists(verificacion.id))
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
            return View(verificacion);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarAsignacion(int id, [Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion,Identidad,Nombre_Cliente,Tienda,Status,Gestor")] Verificacion verificacion)
        {
            if (id != verificacion.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerificacionExists(verificacion.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction(nameof(IndexAsignacion));
            }
            return View(verificacion);
        }

        // GET: Verificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Verificacion == null)
            {
                return NotFound();
            }

            var verificacion = await _context.Verificacion
                .FirstOrDefaultAsync(m => m.id == id);
            if (verificacion == null)
            {
                return NotFound();
            }

            return View(verificacion);
        }

        // POST: Verificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Verificacion == null)
            {
                return Problem("Entity set 'Appdbcontext.Verificacion'  is null.");
            }
            var verificacion = await _context.Verificacion.FindAsync(id);
            if (verificacion != null)
            {
                _context.Verificacion.Remove(verificacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerificacionExists(int id)
        {
          return (_context.Verificacion?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
