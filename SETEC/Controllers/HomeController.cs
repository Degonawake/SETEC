using Microsoft.AspNetCore.Mvc;
using SETEC.Models;
using System.Diagnostics;

namespace SETEC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        //public IActionResult Inforoute1()
        //{
          //  return View();
        //}

        public IActionResult Index() //mapear la vista y lograr retornarla
        {
            return View(); 
        }

        public IActionResult Contacto() //mapear la vista y lograr retornarla
        {
            return View();
        }

        public IActionResult Usuarios() //mapear la vista y lograr retornarla
        {
            return View();
        }

        public IActionResult pruebaJs() //mapear la vista y lograr retornarla
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


     


    }


}