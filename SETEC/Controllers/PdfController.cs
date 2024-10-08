using PdfSharp.Pdf;
using PdfSharp.Drawing;
using Microsoft.AspNetCore.Mvc;
using System.IO;

public class PdfController : Controller
{
    public IActionResult GeneratePdf()
    {
        using (var ms = new MemoryStream())
        {
            // Crear un nuevo documento PDF
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Dibujar texto
            gfx.DrawString("Hola, Mundo!", new XFont("Verdana", 20), XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            // Guardar el documento en el MemoryStream
            document.Save(ms, false);

            // Retornar el archivo PDF
            return File(ms.ToArray(), "application/pdf", "MiDocumento.pdf");
        }
    }
}