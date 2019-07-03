using CS.DAL.Repository;
using CS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Interface
{
    public interface ICustomer: IRepository<Customer>
    {
        Task<List<Customer>> GetAll();
    }
}
