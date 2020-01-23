using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GoogleChartsAPI_AspNet_MVC.Models;


namespace GoogleChartsAPI_AspNet_MVC.Db
{
    /// <summary>
    /// This class handles the sqlite database
    /// </summary>
    public class PopulationDataHelper3 : DbContext
    {
        /// <summary>
        /// This property allows to manipulate the Population2 table
        /// </summary>
        public DbSet<PopulationModel3> PopulationModels3 { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./population3.sqlite");
        }
    }
}