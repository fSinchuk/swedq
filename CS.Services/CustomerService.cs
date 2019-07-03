using CS.DAL;
using CS.DAL.Repository;
using CS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Services
{
    public class CustomerService : ICustomerServeice
    {
        IRepository<Customer> repo;
        public CustomerService(IRepository<Customer> repo) => this.repo = repo;
        public Task<List<Customer>> GetByName(string name)=> repo.Get(w=>w.Name.Contains(name));
    }
}
