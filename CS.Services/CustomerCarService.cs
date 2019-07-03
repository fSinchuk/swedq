using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS.DAL;
using CS.DAL.Interface;
using CS.DAL.Repository;
using CS.Models;
using Microsoft.EntityFrameworkCore;

namespace CS.Services
{
    public class CustomerCarService : ICustomerCarService
    {
        ICustomerCarRepository repo;

        public CustomerCarService(ICustomerCarRepository repo) => this.repo = repo;

        public Task<List<Customer_Car>> GetAll() => repo.GetAll();
        public Task<List<Customer_Car>> GetByRegNumber(string number) => repo.GetByRegNumber(number);
        public Task<List<Customer_Car>> GetByVin(string vin) => repo.GetByVin(vin);
        public Task<List<Customer_Car>> GetByCustomerName(string name) => repo.GetByCustomerName(name);

        public async void UpdateStatus(int cardId, short statusId) {
            var car = await repo.GetByID(cardId);
            car.StatusId = statusId;
            await repo.Save(car);
        }
    }
}
