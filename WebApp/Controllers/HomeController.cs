using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            bool estaLoggeado = HttpContext.Session.GetInt32("LogueadoId") != null;

            if (estaLoggeado)
            {
             
                ViewBag.Nombre = HttpContext.Session.GetString("NombreUsuario");
                ViewBag.Rol = HttpContext.Session.GetString("LogueadoRol");
            }

            ViewBag.EstaLoggeado = estaLoggeado;  
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
