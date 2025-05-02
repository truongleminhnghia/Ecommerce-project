using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.DAL.Base;
using ShoppEcommerce_WebApp.DAL.Context;

namespace ShoppEcommerce_WebApp.DAL.Reposiroties.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context) { }
    }
}
