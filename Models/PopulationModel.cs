using System.ComponentModel.DataAnnotations;

namespace GoogleChartsAPI_AspNet_MVC.Models
{
    public class PopulationModel
    {
        [Key]
        public string CityName { get; set; }
        public int PopulationYear2010 { get; set; }
        public int PopulationYear2000 { get; set; }
    }
}