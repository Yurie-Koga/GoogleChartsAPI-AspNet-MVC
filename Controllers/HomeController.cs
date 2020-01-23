﻿using System;
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
        /// Chart
        /// </sammary>
        public IActionResult Chart() { return View(); }

        // Use at Chart.cshtml >LoadData >url: '@Url.Action("PopulationChart","Home")'
        public JsonResult PopulationChart()
        {
            var populationList = PopulationDataHelper.GetUsStatePopulationList();
            return Json(populationList);
        }



        /// <sammary>
        /// Chart3
        /// </sammary>
        public IActionResult Chart3() { return View(); }

        // Use at Chart3.cshtml >LoadData >url: "/Home/PopulationChart3"
        public JsonResult PopulationChart3()
        {
            using (var context = new PopulationDataHelper3())
            {
                // Clear and reset database
                context.Database.EnsureDeleted();

                // Create database if it does not exist
                context.Database.EnsureCreated();

                // Add records: Id is autoincremented by default               
                context.PopulationModels3.Add(new PopulationModel3 { CityName = "City-1", PopulationYear2010 = 3000, PopulationYear2000 = 1000 });
                context.PopulationModels3.Add(new PopulationModel3 { CityName = "City-2", PopulationYear2010 = 2500, PopulationYear2000 = 1500 });
                context.PopulationModels3.Add(new PopulationModel3 { CityName = "City-3", PopulationYear2010 = 2000, PopulationYear2000 = 2000 });
                context.PopulationModels3.Add(new PopulationModel3 { CityName = "City-4", PopulationYear2010 = 1500, PopulationYear2000 = 2500 });
                context.PopulationModels3.Add(new PopulationModel3 { CityName = "City-5", PopulationYear2010 = 1000, PopulationYear2000 = 3000 });

                // Commit changes
                context.SaveChanges();

                // Fetch all Population2         
                var list = new List<PopulationModel3>();
                foreach (var population in context.PopulationModels3.ToList())
                {
                    list.Add(new PopulationModel3
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
