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

        // Use at Chart.cshtml >LoadData >url: '@Url.Action("PopulationChart","Home")'
        public JsonResult PopulationChart()
        {
            var populationList = PopulationDataHelper.GetUsStatePopulationList();
            return Json(populationList);
        }

        public IActionResult Chart2()
        {
            return View();
        }
        // Use at Chart2.cshtml >LoadData >url: '@Url.Action("PopulationChart2","Home")'
        public JsonResult PopulationChart2()
        {
            using (var context = new PopulationDataHelper2())
            {
                // Clear and reset database
                context.Database.EnsureDeleted();

                // Create database if it does not exist
                context.Database.EnsureCreated();

                // Add records: Id is autoincremented by default
                // Pattern 1
                context.PopulationModels2.Add(new PopulationModel2
                {
                    CityName = "LA",
                    PopulationYear2010 = 2000,
                    PopulationYear2000 = 1900
                });
                // Pattern 2
                var WA = new PopulationModel2();
                WA.CityName = "WA";
                WA.PopulationYear2010 = 1800;
                WA.PopulationYear2000 = 1700;
                context.PopulationModels2.Add(WA);

                // Commit changes
                context.SaveChanges();

                // Fetch all Population2         
                var list = new List<PopulationModel2>();
                foreach (var population in context.PopulationModels2.ToList())
                {
                    list.Add(new PopulationModel2
                    {
                        CityName = population.CityName,
                        PopulationYear2010 = population.PopulationYear2010,
                        PopulationYear2000 = population.PopulationYear2000
                    });
                }
                return Json(list);
            }
        }
    }
}
