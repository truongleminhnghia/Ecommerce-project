using ShoppEcommerce_WebApp.DAL.Reposiroties.AccountRepository;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Addresses;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Customers;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Employees;
using ShoppEcommerce_WebApp.DAL.Reposiroties.RoleRepository;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Stores;

namespace ShoppEcommerce_WebApp.DAL
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IRoleRepository Roles { get; }
        ICustomerRepository Customers { get; }
        IEmployeeRepository Employees { get; }
        IStoreRepository Stores { get; }
        IAddressRepository Addresses { get; }
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesWithTransactionAsync();
        int SaveChangesWithTransaction();  // Lưu thay đổi với transaction đồng bộ
    }
}
