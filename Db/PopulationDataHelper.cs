using System.Collections;
using System.Collections.Generic;
using GoogleChartsAPI_AspNet_MVC.Models;

namespace GoogleChartsAPI_AspNet_MVC.Db
{
    public class PopulationDataHelper
    {
        public static List<PopulationModel> GetUsStatePopulationList()
        {
            var list = new List<PopulationModel>();
            list.Add(new PopulationModel { CityName = "New York City, NY", PopulationYear2010 = 1000, PopulationYear2000 = 900 });
            list.Add(new PopulationModel { CityName = "Chicago, IL", PopulationYear2010 = 800, PopulationYear2000 = 700 });
            return list;
        }
    }
}