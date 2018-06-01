using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entities
{
    public class CityInfoContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public CityInfoContext(DbContextOptions<CityInfoContext> options): base(options)
        {
             Database.Migrate();
            // Run the command in package manager console- Adding the Add-Migration CityInfoDBInitialMigrations
            // Update-Database to maintain the history of migration.
            // Database.EnsureCreated();
        }
        public DbSet<City> cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }

}
