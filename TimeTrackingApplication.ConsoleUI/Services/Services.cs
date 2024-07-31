using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApplication.Repository.DBContext;

namespace TimeTrackingApplication.ConsoleUI.Services
{
    public static class Services
    {
        public static ServiceProvider SetServiceProvider()
        {
            return new ServiceCollection()
            .AddDbContext<TimeTrackingApplicationDBContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TimeTrackingApplicationDB;Trusted_Connection=True;"))
            .BuildServiceProvider();
        }
    }
}
