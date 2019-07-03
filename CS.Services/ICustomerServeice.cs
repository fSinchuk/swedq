using CS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Services
{
    public interface ICustomerServeice
    {
        Task<List<Customer>> GetByName(string name);
    }
}
