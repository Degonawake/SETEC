using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Data.Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

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




        public async Task<ActionResult> InfoVerificacion(string search, string searchDate, string searchGestor)
        {


            Console.WriteLine($"Valor de Identidad: {search} Fecha: {searchDate} Gestor: {searchGestor}");
            var allactual = from Verificacion in _context.Verificacion select Verificacion;
            var allactualDropDown = from ActualidadCliente in _context.ActualidadClientes select ActualidadCliente;



            if (!String.IsNullOrEmpty(search) || !String.IsNullOrEmpty(searchDate) || !String.IsNullOrEmpty(searchGestor))
            {
                allactual = allactual.Where(s =>
                    (String.IsNullOrEmpty(search) || s.Identidad!.Contains(search)) &&
                    (String.IsNullOrEmpty(searchDate) || s.Fecha_Verificacion == DateTime.Parse(searchDate)) &&
                    (String.IsNullOrEmpty(searchGestor) || s.Gestor == searchGestor)
                );


            }



            return View(allactual);
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
        public async Task<IActionResult> Create([Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion,Identidad,Nombre_Cliente,Tienda,Tel_Empresa_Labor,Empresa_Labor,Colonia_Empresa_Labor,Bloque_Empresa_Labor,Peatonal_Empresa_Labor,ZonaEtapa_Empresa_Labor,Calle_Empresa_Labor,Ave_Empresa_Labor,Sector_Empresa_Labor,Casa_Empresa_Labor,Planta1_Empresa_Labor,Planta2_Empresa_Labor,Edificio_Empresa_Labor,Color_Empresa_Labor,Sucursal_Empresa_Labor,DireccionSucursal_Empresa_Labor,Local,TiempoLocal,TiempoLocalActual,TiempoLocalAnterior,ColoniaLocalAnterior,ClienteEmpresa,PermisoOperacion,FotografiaPermisoOperacion,CotizaRap,CotizaIHSS,CotizaINJUPEMP,FormadePago,TamEmpresa,RubroEmpresa,IngresoMensual,HorasExtras,Promedio,FechaIngreso,Puesto,Depto,JefeInmediato,HorarioTrabajo,TelefonoCliente,TelefonoRRHH,PersonaConfirma,PuestoPersonaConfirma,MoviemientoClientes,Mobiliario,Estacionamiento,FotoEstacionamiento,StatusConformacion,RazonNoConfirmacion,SeSugiereNuevaVisita,RazonNuevaVisita,SePudoRealizar,RazonNoRealizacion,Dictamen,Gestor,UbicacionGPS,Status, Comentario")] Verificacion verificacion, IFormFile file)
        {

            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    var key = state.Key;
                    var errors = state.Value.Errors;

                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }
                return View(verificacion);
            }
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    try
                    {
                        // Generar un nombre único para el archivo
                        var fileExtension = Path.GetExtension(file.FileName);
                        var fileName = $"{verificacion.Identidad}_{DateTime.Now:yyyyMMddHHmmss}{fileExtension}";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        verificacion.Archivo = fileName; // Guarda el nombre del archivo en la entidad
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores (puedes registrar el error o mostrar un mensaje al usuario)
                        Console.WriteLine($"Error al cargar el archivo: {ex.Message}");
                        ModelState.AddModelError(string.Empty, "No se pudo cargar el archivo. Inténtalo de nuevo.");
                        return View(verificacion);
                    }
                }
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

        public async Task<IActionResult> EditCreacion(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion,Identidad,Nombre_Cliente,Tienda,Tel_Empresa_Labor,Empresa_Labor,Colonia_Empresa_Labor,Bloque_Empresa_Labor,Peatonal_Empresa_Labor,ZonaEtapa_Empresa_Labor,Calle_Empresa_Labor,Ave_Empresa_Labor,Sector_Empresa_Labor,Casa_Empresa_Labor,Planta1_Empresa_Labor,Planta2_Empresa_Labor,Edificio_Empresa_Labor,Color_Empresa_Labor,Sucursal_Empresa_Labor,DireccionSucursal_Empresa_Labor,Local,TiempoLocal,TiempoLocalActual,TiempoLocalAnterior,ColoniaLocalAnterior,ClienteEmpresa,PermisoOperacion,FotografiaPermisoOperacion,CotizaRap,CotizaIHSS,CotizaINJUPEMP,FormadePago,TamEmpresa,RubroEmpresa,IngresoMensual,HorasExtras,Promedio,FechaIngreso,Puesto,Depto,JefeInmediato,HorarioTrabajo,TelefonoCliente,TelefonoRRHH,PersonaConfirma,PuestoPersonaConfirma,MoviemientoClientes,Mobiliario,Estacionamiento,FotoEstacionamiento,StatusConformacion,RazonNoConfirmacion,SeSugiereNuevaVisita,RazonNuevaVisita,SePudoRealizar,RazonNoRealizacion,Dictamen,Gestor,UbicacionGPS,archivo")] Verificacion verificacion)
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
        public async Task<IActionResult> EditarAsignacion(int id, [Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion," +
            "Identidad,Nombre_Cliente,Tienda,Tel_Empresa_Labor,Empresa_Labor,Colonia_Empresa_Labor," +
            "Bloque_Empresa_Labor,Peatonal_Empresa_Labor,ZonaEtapa_Empresa_Labor,Calle_Empresa_Labor," +
            "Ave_Empresa_Labor,Sector_Empresa_Labor,Casa_Empresa_Labor,Planta1_Empresa_Labor,Planta2_Empresa_Labor," +
            "Edificio_Empresa_Labor,Color_Empresa_Labor,Sucursal_Empresa_Labor,DireccionSucursal_Empresa_Labor,Local," +
            "TiempoLocal,TiempoLocalActual,TiempoLocalAnterior,ColoniaLocalAnterior,ClienteEmpresa,PermisoOperacion," +
            "FotografiaPermisoOperacion,CotizaRap,CotizaIHSS,CotizaINJUPEMP,FormadePago,TamEmpresa,RubroEmpresa," +
            "IngresoMensual,HorasExtras,Promedio,FechaIngreso,Puesto,Depto,JefeInmediato,HorarioTrabajo,TelefonoCliente," +
            "TelefonoRRHH,PersonaConfirma,PuestoPersonaConfirma,MoviemientoClientes,Mobiliario,Estacionamiento," +
            "FotoEstacionamiento,StatusConformacion,RazonNoConfirmacion,SeSugiereNuevaVisita,RazonNuevaVisita," +
            "SePudoRealizar,RazonNoRealizacion,Dictamen,Gestor,UbicacionGPS,Status,Comentario,Usuario,Archivo")]
        Verificacion verificacion)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCreacion(int id, [Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion," +
            "Identidad,Nombre_Cliente,Tienda,Tel_Empresa_Labor,Empresa_Labor,Colonia_Empresa_Labor," +
            "Bloque_Empresa_Labor,Peatonal_Empresa_Labor,ZonaEtapa_Empresa_Labor,Calle_Empresa_Labor," +
            "Ave_Empresa_Labor,Sector_Empresa_Labor,Casa_Empresa_Labor,Planta1_Empresa_Labor,Planta2_Empresa_Labor," +
            "Edificio_Empresa_Labor,Color_Empresa_Labor,Sucursal_Empresa_Labor,DireccionSucursal_Empresa_Labor,Local," +
            "TiempoLocal,TiempoLocalActual,TiempoLocalAnterior,ColoniaLocalAnterior,ClienteEmpresa,PermisoOperacion," +
            "FotografiaPermisoOperacion,CotizaRap,CotizaIHSS,CotizaINJUPEMP,FormadePago,TamEmpresa,RubroEmpresa," +
            "IngresoMensual,HorasExtras,Promedio,FechaIngreso,Puesto,Depto,JefeInmediato,HorarioTrabajo,TelefonoCliente," +
            "TelefonoRRHH,PersonaConfirma,PuestoPersonaConfirma,MoviemientoClientes,Mobiliario,Estacionamiento," +
            "FotoEstacionamiento,StatusConformacion,RazonNoConfirmacion,SeSugiereNuevaVisita,RazonNuevaVisita," +
            "SePudoRealizar,RazonNoRealizacion,Dictamen,Gestor,UbicacionGPS,Status,Comentario,Usuario,Archivo")]
        Verificacion verificacion)
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
        public async Task<IActionResult> Verificacionupdate(int id, [Bind("id,Fecha_Creacion,Fecha_Verificacion,Empresa_Verificacion," +
            "Identidad,Nombre_Cliente,Tienda,Tel_Empresa_Labor,Empresa_Labor,Colonia_Empresa_Labor," +
            "Bloque_Empresa_Labor,Peatonal_Empresa_Labor,ZonaEtapa_Empresa_Labor,Calle_Empresa_Labor," +
            "Ave_Empresa_Labor,Sector_Empresa_Labor,Casa_Empresa_Labor,Planta1_Empresa_Labor,Planta2_Empresa_Labor," +
            "Edificio_Empresa_Labor,Color_Empresa_Labor,Sucursal_Empresa_Labor,DireccionSucursal_Empresa_Labor,Local," +
            "TiempoLocal,TiempoLocalActual,TiempoLocalAnterior,ColoniaLocalAnterior,ClienteEmpresa,PermisoOperacion," +
            "FotografiaPermisoOperacion,CotizaRap,CotizaIHSS,CotizaINJUPEMP,FormadePago,TamEmpresa,RubroEmpresa," +
            "IngresoMensual,HorasExtras,Promedio,FechaIngreso,Puesto,Depto,JefeInmediato,HorarioTrabajo,TelefonoCliente," +
            "TelefonoRRHH,PersonaConfirma,PuestoPersonaConfirma,MoviemientoClientes,Mobiliario,Estacionamiento," +
            "FotoEstacionamiento,StatusConformacion,RazonNoConfirmacion,SeSugiereNuevaVisita,RazonNuevaVisita," +
            "SePudoRealizar,RazonNoRealizacion,Dictamen,Gestor,UbicacionGPS,Status,Comentario,Usuario,Archivo")]
        Verificacion verificacion)
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
                catch (Exception ex)
                {
                    if (!VerificacionExists(verificacion.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    Console.WriteLine(ex.Message);
                }
                return RedirectToAction("InfoVerificacion", "Verificacion");
            }

            return RedirectToAction("Error");
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


        public async Task<IActionResult> GeneratePdf(int id)
        {
            var verificacion = await _context.Verificacion.FindAsync(id);
            if (verificacion == null)
            {
                return NotFound();
            }

            var pdf = new PdfDocument();
            var page = pdf.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Definir fuentes y colores
            var fontTitle = new XFont("Verdana", 16, XFontStyleEx.Bold);
            var fontHeader = new XFont("Verdana", 12, XFontStyleEx.Bold);
            var fontContent = new XFont("Verdana", 10);
            var blueBrush = XBrushes.Blue;
            var blackBrush = XBrushes.Black;
            var borderPen = new XPen(XColors.Gray, 1);
            var titleBrush = XBrushes.DarkBlue;
            var headerBrush = XBrushes.DarkSlateGray;
            var headerTextColor = XBrushes.White;
            var rowEvenBackground = XBrushes.LightGray;
            var rowOddBackground = XBrushes.White;

            // Título principal
            gfx.DrawString("Reporte de Verificación PRUEBA DE AVANCE", fontTitle, titleBrush, new XRect(0, 40, page.Width, 50), XStringFormats.Center);

            // Encabezado de la tabla
            double yPos = 100;
            double rowHeight = 25;
            double columnWidth1 = 250;
            double columnWidth2 = page.Width - columnWidth1 - 80;

            // Encabezado con fondo oscuro y texto blanco
            gfx.DrawRectangle(headerBrush, 40, yPos - rowHeight, page.Width - 80, rowHeight);
            gfx.DrawString("Campo", fontHeader, headerTextColor, new XRect(40, yPos - rowHeight, columnWidth1, rowHeight), XStringFormats.Center);
            gfx.DrawString("Valor", fontHeader, headerTextColor, new XRect(40 + columnWidth1, yPos - rowHeight, columnWidth2, rowHeight), XStringFormats.Center);

            yPos += rowHeight;

            var content = new[]
            {
        ("Fecha de Creación:", verificacion.Fecha_Creacion.ToString("d")),
        ("Fecha de Verificación:", verificacion.Fecha_Verificacion.ToString("d")),
        ("Empresa de Verificación:", verificacion.Empresa_Verificacion),
        ("Identidad:", verificacion.Identidad),
        ("Nombre del Cliente:", verificacion.Nombre_Cliente),
        ("Tienda:", verificacion.Tienda),
        ("Teléfono de la Empresa de Labor:", verificacion.Tel_Empresa_Labor),
        ("Empresa de Labor:", verificacion.Empresa_Labor),
        ("Colonia Empresa de Labor:", verificacion.Colonia_Empresa_Labor),
        ("Bloque Empresa de Labor:", verificacion.Bloque_Empresa_Labor),
        ("Peatonal Empresa de Labor:", verificacion.Peatonal_Empresa_Labor),
        ("Zona Etapa Empresa de Labor:", verificacion.ZonaEtapa_Empresa_Labor),
        ("Calle Empresa de Labor:", verificacion.Calle_Empresa_Labor),
        ("Avenida Empresa de Labor:", verificacion.Ave_Empresa_Labor),
        ("Sector Empresa de Labor:", verificacion.Sector_Empresa_Labor),
        ("Casa Empresa de Labor:", verificacion.Casa_Empresa_Labor),
        ("Planta 1 Empresa de Labor:", verificacion.Planta1_Empresa_Labor == true ? "Sí" : "No"),
        ("Planta 2 Empresa de Labor:", verificacion.Planta2_Empresa_Labor == true ? "Sí" : "No"),
        ("Edificio Empresa de Labor:", verificacion.Edificio_Empresa_Labor == true ? "Sí" : "No"),
        ("Color Empresa de Labor:", verificacion.Color_Empresa_Labor),
        ("Sucursal Empresa de Labor:", verificacion.Sucursal_Empresa_Labor == true ? "Sí" : "No"),
        ("Dirección Sucursal Empresa de Labor:", verificacion.DireccionSucursal_Empresa_Labor),
        ("Local:", verificacion.Local),
        ("Tiempo Local:", verificacion.TiempoLocal),
        ("Tiempo Local Actual:", verificacion.TiempoLocalActual),
        ("Tiempo Local Anterior:", verificacion.TiempoLocalAnterior),
        ("Colonia Local Anterior:", verificacion.ColoniaLocalAnterior),
        ("Cliente Empresa:", verificacion.ClienteEmpresa),
        ("Permiso de Operación:", verificacion.PermisoOperacion == true ? "Sí" : "No"),
        ("Fotografía Permiso de Operación:", verificacion.FotografiaPermisoOperacion),
        ("Cotiza RAP:", verificacion.CotizaRap == true ? "Sí" : "No"),
        ("Cotiza IHSS:", verificacion.CotizaIHSS == true ? "Sí" : "No"),
        ("Cotiza INJUPEMP:", verificacion.CotizaINJUPEMP == true ? "Sí" : "No"),
        ("Forma de Pago:", verificacion.FormadePago),
        ("Tamaño de la Empresa:", verificacion.TamEmpresa),
        ("Rubro de la Empresa:", verificacion.RubroEmpresa),
        ("Ingreso Mensual:", verificacion.IngresoMensual?.ToString("C")),
        ("Horas Extras:", verificacion.HorasExtras == true ? "Sí" : "No"),
        ("Promedio:", verificacion.Promedio?.ToString("C")),
        ("Fecha de Ingreso:", verificacion.FechaIngreso?.ToString("d")),
        ("Puesto:", verificacion.Puesto),
        ("Departamento:", verificacion.Depto),
        ("Jefe Inmediato:", verificacion.JefeInmediato),
        ("Horario de Trabajo:", verificacion.HorarioTrabajo),
        ("Teléfono del Cliente:", verificacion.TelefonoCliente),
        ("Teléfono RRHH:", verificacion.TelefonoRRHH),
        ("Persona que Confirma:", verificacion.PersonaConfirma),
        ("Puesto Persona que Confirma:", verificacion.PuestoPersonaConfirma),
        ("Movimiento de Clientes:", verificacion.MoviemientoClientes),
        ("Mobiliario:", verificacion.Mobiliario),
        ("Estacionamiento:", verificacion.Estacionamiento == true ? "Sí" : "No"),
        ("Foto de Estacionamiento:", verificacion.FotoEstacionamiento),
        ("Status de Confirmación:", verificacion.StatusConformacion),
        ("Razón de No Confirmación:", verificacion.RazonNoConfirmacion),
        ("Se Sugiere Nueva Visita:", verificacion.SeSugiereNuevaVisita == true ? "Sí" : "No"),
        ("Razón de Nueva Visita:", verificacion.RazonNuevaVisita),
        ("Se Pudo Realizar:", verificacion.SePudoRealizar == true ? "Sí" : "No"),
        ("Razón de No Realización:", verificacion.RazonNoRealizacion),
        ("Dictamen:", verificacion.Dictamen),
        ("Gestor:", verificacion.Gestor),
        ("Ubicación GPS:", verificacion.UbicacionGPS),
        ("Status:", verificacion.Status),
        ("Comentario:", verificacion.Comentario),
        ("Usuario:", verificacion.Usuario),
        ("Archivo:", verificacion.Archivo)
    };

            bool isEvenRow = true;
            foreach (var (label, value) in content)
            {
                if (yPos < 60) // Añadir nueva página si es necesario
                {
                    page = pdf.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    yPos = 100;
                    gfx.DrawString("Reporte de Verificación", fontTitle, titleBrush, new XRect(0, 40, page.Width, 50), XStringFormats.Center);
                }

                var rowBackground = isEvenRow ? rowEvenBackground : rowOddBackground;

                // Fondo alterno para filas
                gfx.DrawRectangle(rowBackground, 40, yPos, columnWidth1, rowHeight);
                gfx.DrawRectangle(rowBackground, 40 + columnWidth1, yPos, columnWidth2, rowHeight);

                // Bordes
                gfx.DrawRectangle(borderPen, 40, yPos, columnWidth1, rowHeight);
                gfx.DrawRectangle(borderPen, 40 + columnWidth1, yPos, columnWidth2, rowHeight);

                // Contenido
                gfx.DrawString(label, fontContent, blackBrush, new XRect(40, yPos, columnWidth1, rowHeight), XStringFormats.TopLeft);
                gfx.DrawString(value ?? "N/A", fontContent, blackBrush, new XRect(40 + columnWidth1, yPos, columnWidth2, rowHeight), XStringFormats.TopLeft);

                yPos += rowHeight;
                isEvenRow = !isEvenRow;
            }

            // Encabezado y pie de página
            gfx.DrawString("Reporte de Verificación", fontHeader, titleBrush, new XRect(40, 10, page.Width, 30), XStringFormats.TopLeft);
            gfx.DrawString(DateTime.Now.ToString("d MMM yyyy"), fontContent, blackBrush, new XRect(page.Width - 150, 10, 100, 30), XStringFormats.TopRight);
            gfx.DrawString($"Página {pdf.PageCount}", fontContent, blackBrush, new XRect(0, page.Height - 30, page.Width, 20), XStringFormats.Center);

            var stream = new MemoryStream();
            pdf.Save(stream, false);
            stream.Position = 0;
            return File(stream.ToArray(), "application/pdf", "Verificacion.pdf");
        }

        private byte[] GeneratePdfFromVerificacion(Verificacion verificacion)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Crear un nuevo documento PDF
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Verificación";

                // Crear una página en blanco
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Verdana", 12);

                // Definir una posición inicial para el texto
                int yPos = 40;

                // Escribir los campos del modelo en el PDF
                gfx.DrawString("ID: " + verificacion.id, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Fecha de Creación: " + verificacion.Fecha_Creacion.ToString("dd/MM/yyyy"), font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Fecha de Verificación: " + verificacion.Fecha_Verificacion.ToString("dd/MM/yyyy"), font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Empresa de Verificación: " + verificacion.Empresa_Verificacion, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Identidad: " + verificacion.Identidad, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Nombre del Cliente: " + verificacion.Nombre_Cliente, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Tienda: " + verificacion.Tienda, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Teléfono Empresa Labor: " + verificacion.Tel_Empresa_Labor, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Empresa Labor: " + verificacion.Empresa_Labor, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                gfx.DrawString("Colonia Empresa Labor: " + verificacion.Colonia_Empresa_Labor, font, XBrushes.Black, new XRect(40, yPos, page.Width, page.Height), XStringFormats.TopLeft);
                yPos += 20;
                // Agregar más campos según sea necesario

                // Guardar el documento en un MemoryStream
                document.Save(stream, false);

                return stream.ToArray();
            }
        }
    }
}
