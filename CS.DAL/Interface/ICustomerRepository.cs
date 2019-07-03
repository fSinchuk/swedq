using CS.DAL.Repository;
using CS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Interface
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<List<Customer>> GetAll();
    }
}
