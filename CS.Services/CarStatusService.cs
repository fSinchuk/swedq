using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CS.DAL;
using CS.DAL.Repository;
using CS.Models;
using Microsoft.EntityFrameworkCore;

namespace CS.Services
{
    public class CarStatusService : ICarStatusService
    {
        IRepository<Car_Status> repo;
        public CarStatusService(IRepository<Car_Status> repo) => this.repo = repo;
        public Task<List<Car_Status>> GetAll() => repo.GetAll();
    }
}
