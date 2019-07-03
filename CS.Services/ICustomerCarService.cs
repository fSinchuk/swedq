using CS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Services
{
    public interface ICustomerCarService
    {
        Task<List<Customer_Car>> GetAll();
        Task<List<Customer_Car>> GetByVin(string vin);
        Task<List<Customer_Car>> GetByRegNumber(string regNum);
        Task<List<Customer_Car>> GetByCustomerName(string name);
        void UpdateStatus(int cardId, short statusId);
    }
}
