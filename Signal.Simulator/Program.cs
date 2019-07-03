using CS.DAL;
using CS.DAL.Interface;
using CS.DAL.Repository;
using CS.Models;
using CS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Signal.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("CarSignalDb");

            Console.WriteLine(connectionString);

            var serviceProvider = new ServiceCollection().
                 AddDbContext<DashboardContext>(options => options.UseSqlServer(connectionString)).
                 AddScoped<ICustomerCarRepository, CustomerCarRepository>().
                 AddScoped<IRepository<Car_Status>, Repository<Car_Status>>().
                 AddTransient<ICarStatusService, CarStatusService>().
                 AddTransient<ICustomerCarService, CustomerCarService>().
                 BuildServiceProvider();
            
            
            ICarStatusService carStatusService = serviceProvider.GetService<ICarStatusService>();
            ICustomerCarService customerCarService = serviceProvider.GetService<ICustomerCarService>();

            Do(carStatusService, customerCarService);
        }

        static  void Do(ICarStatusService carStatusService, ICustomerCarService customerCarService)
        {
            for (; ; )
            {
                Random rand = new Random();

                var statuses = carStatusService.GetAll().Result;
                var customerCars = customerCarService.GetAll().Result;

                int statusIndex = GetRandom(statuses, rand);
                int carIndex = GetRandom(customerCars, rand);

                var statusToSet = statuses.ElementAt(statusIndex);
                var carToChange = customerCars.ElementAt(carIndex);

                customerCarService.UpdateStatus(carToChange.Id, statusToSet.Id);

                Console.WriteLine(DateTime.Now);
                Thread.Sleep(3000);
            }
        }

        static int GetRandom(IEnumerable<Entity> list, Random rand) => rand.Next(0, list.Count());
    }
}
