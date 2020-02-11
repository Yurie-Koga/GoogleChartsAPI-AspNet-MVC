using System.ComponentModel.DataAnnotations;

namespace GoogleChartsAPI_AspNet_MVC.Models
{
    public class CakeModel
    {
        [Key]
        public string CakeName { get; set; }
        public int EatenYear2019 { get; set; }
        public int EatenYear2015 { get; set; }
        public int EatenYear2010 { get; set; }
        public int EatenYear2005 { get; set; }
    }
}