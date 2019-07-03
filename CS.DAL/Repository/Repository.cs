using CS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Repository
{

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DashboardContext context;
        public Repository(DashboardContext context)
        {
            this.context = context;
        }


        public virtual async Task AddAsync(T Item)
        {
            context.Add(Item);
            await context.SaveChangesAsync();
        }

        public virtual async Task AddAll(IEnumerable<T> Items)
        {
            context.AddRange(Items);
            await context.SaveChangesAsync();
        }

        public virtual async Task Delete(int Id)
        {
            context.Remove(await GetByID(Id));
            await context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includingProperties = "", int? skip = null, int? take = null)
        {
            IQueryable<T> query = context.Set<T>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            foreach (string item in includingProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            //Console.WriteLine(query.ToString());

            return await query.ToListAsync();
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByID(int Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }

        public virtual async Task Save(T Item)
        {
            context.Update(Item);
            await context.SaveChangesAsync();
        }

        public virtual async Task SaveAll(IEnumerable<T> Items)
        {
            context.UpdateRange(Items);
            await context.SaveChangesAsync();
        }
    }
}
