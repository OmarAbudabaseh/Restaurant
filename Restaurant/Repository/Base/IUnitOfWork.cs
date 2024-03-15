using Restaurant.Models;

namespace Restaurant.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> categories { get; }

        IRepository<Item> items { get; }

        IEmpRepo employees { get; }
        int CommitChanges();
        public void Dispose();

    }
}
