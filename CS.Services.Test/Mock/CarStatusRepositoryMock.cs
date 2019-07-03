using CS.DAL.Repository;
using CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS.Services.Test.Mock
{
    class CarStatusRepositoryMock : IRepository<Car_Status>
    {
        List<Car_Status> notADatabase = new List<Car_Status>();
        public Task AddAsync(Car_Status Item)
        {
            return Task.Run(() => { notADatabase.Add(Item); });
        }

        public Task AddAll(IEnumerable<Car_Status> Items)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int PrimaryKey)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car_Status>> Get(Expression<Func<Car_Status, bool>> predicate, Func<IQueryable<Car_Status>, IOrderedQueryable<Car_Status>> orderBy = null, string includingProperties = "", int? skip = null, int? take = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car_Status>> GetAll()
        {
            return Task.FromResult(notADatabase);
        }

        public Task<Car_Status> GetByID(int Id)
        {
            return Task.FromResult(notADatabase.Find(s => s.Id == Id));
        }

        public Task Save(Car_Status Item)
        {
            throw new NotImplementedException();
        }

        public Task SaveAll(IEnumerable<Car_Status> Items)
        {
            throw new NotImplementedException();
        }
    }
}
