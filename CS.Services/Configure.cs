using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Services
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services) {
            services.AddTransient<ICarStatusService, CarStatusService>();
            services.AddTransient<ICustomerCarService, CustomerCarService>();
            services.AddTransient<ICustomerServeice, CustomerService>();
        }
    }
}
