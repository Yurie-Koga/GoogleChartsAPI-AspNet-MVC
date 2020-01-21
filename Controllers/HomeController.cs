using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using test_Chart_AspNet_MVC_Csharp.Models;
using test_Chart_AspNet_MVC_Csharp.Db;

namespace test_Chart_AspNet_MVC_Csharp.Controllers
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

        public IActionResult Chart()
        {
            return View();
        }

        public JsonResult PopulationChart()
        {
            var populationList = PopulationDataHelper.GetUsStatePopulationList();
            return Json(populationList);
        }
    }
}
