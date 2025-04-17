using Microsoft.AspNetCore.Mvc;
using ResportesASP.Models;
using Rotativa.AspNetCore;

namespace ReportesAs.Controllers
{
    public class ReporteController : Controller
    {
        // Vista previa normal en HTML
        public IActionResult VerReporte()
        {
            var productos = ObtenerProductosDeEjemplo();
            return View("ReportePDF", productos);
        }

        // Generar el PDF
        public IActionResult GenerarPDF()
        {
            var productos = ObtenerProductosDeEjemplo();

            return new ViewAsPdf("ReportePDF", productos)
            {
                FileName = "ReporteProductos.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageMargins = new Rotativa.AspNetCore.Options.Margins(10, 10, 10, 10)
            };
        }

        // Simula una consulta a base de datos
        private List<Producto> ObtenerProductosDeEjemplo()
        {
            return new List<Producto>
            {
                new Producto { Nombre = "Laptop Gamer", Precio = 2500, Categoria = "Electrónica" },
                new Producto { Nombre = "Smartwatch", Precio = 300, Categoria = "Tecnología" },
                new Producto { Nombre = "Monitor Curvo", Precio = 750, Categoria = "Periféricos" }
            };
        }
    }
}