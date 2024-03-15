using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Repository.Base;

namespace Restaurant.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDBContext context) 
        {
            _context = context;
            categories = new MainRepository<Category>(_context);
            items = new MainRepository<Item>(_context);
            employees = new EmpRepo(_context);
        }

        private readonly AppDBContext _context;

        public IRepository<Category> categories {  get; private set; }

        public IRepository<Item> items { get; private set; }

        public IEmpRepo employees {  get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
