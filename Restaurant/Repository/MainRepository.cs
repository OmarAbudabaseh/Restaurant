using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Repository.Base;
using System.Linq.Expressions;

namespace Restaurant.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDBContext context) 
        {
            this.context = context;
        }

        protected AppDBContext context;
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match); 
        }
        public IEnumerable<T> FindAll() 
        {
            return context.Set<T>().ToList();
        }
        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if(agers.Length > 0)
            {
                foreach(var a in agers)
                {
                    query = query.Include(a); 
                }
            }
            return query.ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }


        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var a in agers)
                {
                    query = query.Include(a);
                }
            }
            return await query.ToListAsync();

        }

        // ====================================================
        public void AddOne(T myItem)
        {
            context.Set<T>().Add(myItem);
            context.SaveChanges();
        }

        public void UpdateOne(T myItem)
        {
            context.Set<T>().Update(myItem);
            context.SaveChanges();
        }

        public void DeleteOne(T myItem)
        {
            context.Set<T>().Remove(myItem);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> myList)
        {
            context.Set<T>().AddRange(myList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> myList)
        {
            context.Set<T>().UpdateRange(myList);
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> myList)
        {
            context.Set<T>().RemoveRange(myList);
            context.SaveChanges();
        }
    }
}
