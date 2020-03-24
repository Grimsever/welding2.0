using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WeldingV2._0.Models;

namespace WeldingV2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InitialData _initial;

        public HomeController(ILogger<HomeController> logger, InitialData initial)
        {
            _logger = logger;
            _initial = initial;
        }

        public IActionResult Index()
        {
            //_initial.AddInitialData();
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
