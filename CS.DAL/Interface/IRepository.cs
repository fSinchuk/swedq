using CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Repository
{
    public interface IRepository<T> where T: Entity
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int Id);
        Task<List<T>> Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includingProperties = "", int? skip = null, int? take = null);
        Task Save(T Item);
        Task AddAsync(T Item);
        Task SaveAll(IEnumerable<T> Items);
        Task AddAll(IEnumerable<T> Items);
        Task Delete(int PrimaryKey);
    }
}
