using CS.DAL.Interface;
using CS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Repository
{
    public class CustomerCarRepository : Repository<Customer_Car>, ICustomerCarRepository
    {
        public CustomerCarRepository(DashboardContext context) : base(context) { }
        public override Task<List<Customer_Car>> GetAll() => context.Customer_Cars.Include("Customer").Include("Car_Status").ToListAsync();
        public Task<List<Customer_Car>> GetByRegNumber(string number) => context.Customer_Cars.Where(w => w.RegNr.Contains(number)).ToListAsync();
        public Task<List<Customer_Car>> GetByVin(string vin) => context.Customer_Cars.Where(w => w.Vin.Contains(vin)).ToListAsync();
        public Task<List<Customer_Car>> GetByCustomerName(string name) => context.Customer_Cars.Include("Customer").Include("Car_Status").Where(w => w.Customer.Name.Contains(name)).ToListAsync();


    }
}
