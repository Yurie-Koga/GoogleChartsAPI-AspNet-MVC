using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GoogleChartsAPI_AspNet_MVC.Models;


namespace GoogleChartsAPI_AspNet_MVC.Db
{
    /// <summary>
    /// This class handles the sqlite database
    /// </summary>
    public class PopulationDbContext : DbContext
    {
        /// <summary>
        /// This property allows to manipulate data table
        /// </summary>
        public DbSet<PopulationModel> PopulationDbSet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./population.sqlite");
        }
    }
}