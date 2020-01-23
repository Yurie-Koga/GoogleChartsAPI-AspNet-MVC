using System.ComponentModel.DataAnnotations;

namespace test_Chart_AspNet_MVC_Csharp.Models
{
    public class PopulationModel3
    {
        [Key]
        public string CityName { get; set; }
        public int PopulationYear2010 { get; set; }
        public int PopulationYear2000 { get; set; }
    }
}