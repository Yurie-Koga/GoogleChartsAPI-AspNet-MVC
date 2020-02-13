using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoogleChartsAPI_AspNet_MVC.Models;
using GoogleChartsAPI_AspNet_MVC.Db;

namespace GoogleChartsAPI_AspNet_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) { _logger = logger; }
        public IActionResult Index() { return View(); }
        public IActionResult Privacy() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <sammary>
        /// PopulationChart
        /// </sammary>
        public IActionResult PopulationChart() { return View(); }

        // Use at PopulationChart.cshtml >LoadData >url: "/Home/PopulationData"
        public JsonResult PopulationData()
        {
            using (var context = new PopulationDbContext())
            {
                // Clear and reset database
                context.Database.EnsureDeleted();

                // Create database if it does not exist
                context.Database.EnsureCreated();

                // Add records: Id is autoincremented by default               
                context.PopulationDbSet.Add(new PopulationModel { CityName = "City-1", PopulationYear2010 = 3000, PopulationYear2000 = 1000 });
                context.PopulationDbSet.Add(new PopulationModel { CityName = "City-2", PopulationYear2010 = 2500, PopulationYear2000 = 1500 });
                context.PopulationDbSet.Add(new PopulationModel { CityName = "City-3", PopulationYear2010 = 2000, PopulationYear2000 = 2000 });
                context.PopulationDbSet.Add(new PopulationModel { CityName = "City-4", PopulationYear2010 = 1500, PopulationYear2000 = 2500 });
                context.PopulationDbSet.Add(new PopulationModel { CityName = "City-5", PopulationYear2010 = 1000, PopulationYear2000 = 3000 });

                // Commit changes
                context.SaveChanges();

                // Fetch all Population         
                var list = new List<PopulationModel>();
                foreach (var population in context.PopulationDbSet.ToList())
                {
                    list.Add(new PopulationModel
                    {
                        CityName = population.CityName,
                        PopulationYear2010 = population.PopulationYear2010,
                        PopulationYear2000 = population.PopulationYear2000
                    });
                }
                return Json(list);
            }
        }

        /// <sammary>
        /// CakeChart
        /// </sammary>
        public IActionResult CakeChart()
        {
            using (var context = new CakeDbContext())
            {
                // Clear and reset database
                // context.Database.EnsureDeleted();

                // Create database if it does not exist
                context.Database.EnsureCreated();

                // Add records: Id is autoincremented by default               
                // context.CakeDbSet.Add(new CakeModel { CakeName = "Cheese", EatenYear2019 = 10, EatenYear2015 = 11, EatenYear2010 = 12, EatenYear2005 = 13 });
                // context.CakeDbSet.Add(new CakeModel { CakeName = "Fruit Tart", EatenYear2019 = 20, EatenYear2015 = 21, EatenYear2010 = 22, EatenYear2005 = 23 });
                // context.CakeDbSet.Add(new CakeModel { CakeName = "Chocolate", EatenYear2019 = 30, EatenYear2015 = 31, EatenYear2010 = 32, EatenYear2005 = 33 });
                // context.CakeDbSet.Add(new CakeModel { CakeName = "Strawberry", EatenYear2019 = 40, EatenYear2015 = 41, EatenYear2010 = 42, EatenYear2005 = 43 });

                // Commit changes
                // context.SaveChanges();

                // Fetch all Cake         
                var list = new List<CakeModel>();
                foreach (var cake in context.CakeDbSet.ToList())
                {
                    list.Add(new CakeModel
                    {
                        CakeName = cake.CakeName,
                        EatenYear2019 = cake.EatenYear2019,
                        EatenYear2015 = cake.EatenYear2015,
                        EatenYear2010 = cake.EatenYear2010,
                        EatenYear2005 = cake.EatenYear2005
                    });
                }
                return View(list);
            }
        }

        // Use at CakeChart.cshtml >LoadData >url: "/Home/CakeData"
        public JsonResult CakeData()
        {
            using (var context = new CakeDbContext())
            {

                // Fetch all Cake         
                var list = new List<CakeModel>();
                foreach (var cake in context.CakeDbSet.ToList())
                {
                    list.Add(new CakeModel
                    {
                        CakeName = cake.CakeName,
                        EatenYear2019 = cake.EatenYear2019,
                        EatenYear2015 = cake.EatenYear2015,
                        EatenYear2010 = cake.EatenYear2010,
                        EatenYear2005 = cake.EatenYear2005
                    });
                }
                return Json(list);
            }
        }

        [HttpPost]
        public ActionResult Create([FromForm]CakeModel newCakeModel)
        {
            Console.WriteLine(newCakeModel);
            if (ModelState.IsValid)
            {
                using (var context = new CakeDbContext())
                {
                    // Create database if it does not exist
                    context.Database.EnsureCreated();

                    context.CakeDbSet.Add(newCakeModel);
                    // Commit changes
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(newCakeModel);
            }
        }
    }
}
