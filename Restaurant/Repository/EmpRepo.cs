using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Repository.Base;

namespace Restaurant.Repository
{
    public class EmpRepo : MainRepository<Employee>, IEmpRepo
    {
        public EmpRepo(AppDBContext context) : base(context)
        {
            _context = context;
        }

        private readonly AppDBContext _context;

        public Decimal getSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
