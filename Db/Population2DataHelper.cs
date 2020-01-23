using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using test_Chart_AspNet_MVC_Csharp.Models;


namespace test_Chart_AspNet_MVC_Csharp.Db
{
    /// <summary>
    /// This class handles the sqlite database
    /// </summary>
    public class PopulationDataHelper2 : DbContext
    {
        /// <summary>
        /// This property allows to manipulate the Population2 table
        /// </summary>
        public DbSet<PopulationModel2> PopulationModels2 { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./population2.sqlite");
        }
    }
}