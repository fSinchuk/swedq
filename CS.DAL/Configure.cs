using CS.DAL.Repository;
using CS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.DAL
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString) {
            services.AddDbContext<DashboardContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository<Customer>, Repository<Customer>>();
            services.AddScoped<IRepository<Customer_Car>, CustomerCarRepository>();
            services.AddScoped<IRepository<Car_Status>, Repository<Car_Status>>();
        }
    }
}
