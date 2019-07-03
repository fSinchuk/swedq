using CS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Services
{
   public interface ICarStatusService
    {
        Task<List<Car_Status>> GetAll();
    }
}
