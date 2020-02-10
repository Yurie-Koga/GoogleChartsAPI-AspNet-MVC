using Microsoft.EntityFrameworkCore;
using GoogleChartsAPI_AspNet_MVC.Models;



namespace GoogleChartsAPI_AspNet_MVC.Db
{
    /// <summary>
    /// This class handles the sqlite database
    /// </summary>
    public class CakeDbContext : DbContext
    {
        /// <summary>
        /// This property allows to manipulate data table
        /// </summary>
        public DbSet<CakeModel> CakeDbSet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./cake.sqlite");
        }
    }

}