using System.Collections;
using System.Collections.Generic;
using test_Chart_AspNet_MVC_Csharp.Models;

namespace test_Chart_AspNet_MVC_Csharp.Db
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