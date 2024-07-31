using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace TimeTrackingApplication.Repository.DBContext
{
    public class TimeTrackingApplicationDBContextFactory : IDesignTimeDbContextFactory<TimeTrackingApplicationDBContext>
    {
        public TimeTrackingApplicationDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TimeTrackingApplicationDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TimeTrackingApplicationDB;Trusted_Connection=True;");

            return new TimeTrackingApplicationDBContext(optionsBuilder.Options);
        }
    }
}
