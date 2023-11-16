using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recepdia.Context;
using Recepedia.Models;
using System.Diagnostics;

namespace Recepedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecepediaContext _context;
        public HomeController(ILogger<HomeController> logger, RecepediaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Receta> ListaRecetas = _context.Receta.ToList();
            ViewBag.ListaRecetas = ListaRecetas;
            ViewBag.Context = _context;
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