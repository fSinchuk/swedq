using CS.DAL.Repository;
using CS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Interface
{
    public interface ICustomerCarRepository : IRepository<Customer_Car>
    {
        Task<List<Customer_Car>> GetByRegNumber(string number);
        Task<List<Customer_Car>> GetByVin(string vin);
        Task<List<Customer_Car>> GetByCustomerName(string name);

    }
}
