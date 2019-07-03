using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CS.DashBoard.Models;

using Microsoft.EntityFrameworkCore;
using CS.DashBoard.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.SignalR;
using CS.DashBoard.Hubs;
using CS.Services;
using CS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS.DashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration config;
        private readonly IHubContext<SignalHub> signalHub;
        private ICustomerCarService carService;


        public HomeController(ICustomerCarService carService, IConfiguration config, IHubContext<SignalHub> signalHub)
        {
            this.config = config;
            this.signalHub = signalHub;
            this.carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Find(string filter, int? serachType=1)
        {
            List<Customer_Car> model = new List<Customer_Car>();

            if (!string.IsNullOrEmpty(filter))
            {
                switch (serachType) {
                    case (int)SearchType.Vin:
                        model = await carService.GetByVin(filter);
                        break;
                    case (int)SearchType.RegNr:
                        model = await carService.GetByRegNumber(filter);
                        break;
                    case (int)SearchType.CustomerName:
                        model = await carService.GetByCustomerName(filter);
                        break;
                }
            }
            else
            {
                model = await carService.GetAll();
            }

            return PartialView("pwCars", model);
        }

        public IActionResult Index()
        {
            new SqlNotification(config, signalHub).Get().ToArray();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
