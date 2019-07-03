using CS.DAL;
using CS.DashBoard.Helpers;
using CS.DashBoard.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CS.DashBoard
{
    public class Startup
    {
        private readonly IHostingEnvironment environment;
        private readonly IConfiguration configuration;
        public Startup(IHostingEnvironment environment)
        {
            this.environment = environment;
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            this.configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services)
        {
            services.AddSingleton(configuration);
            CS.Services.Configure.ConfigureServices(services);
            CS.DAL.Configure.ConfigureServices(services, this.configuration.GetConnectionString("CarSignalDb"));
            
            services.AddSignalR();
            services.AddTransient<SqlNotification>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSignalR(hub=> {
                hub.MapHub<SignalHub>("/signalHub");
            });
                
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
