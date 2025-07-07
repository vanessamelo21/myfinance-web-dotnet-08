using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_dotnet_08.Infrastructure;
using System.Diagnostics;
using myfinance_web_dotnet_08.Models;

namespace myfinance_web_dotnet_08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyfinanceDbContext _context;

        public HomeController(ILogger<HomeController> logger, MyfinanceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var nomePrimeiroPlanoConta  = _context.PlanoContas.FirstOrDefault()?.Nome;
            ViewBag.teste = nomePrimeiroPlanoConta;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PUC()
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
