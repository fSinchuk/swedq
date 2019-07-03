using CS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Interface
{
    public interface ICarStatusRepository{
        Task<List<Car_Status>> GetAll();
    }
}
