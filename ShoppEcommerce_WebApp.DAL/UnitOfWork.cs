using ShoppEcommerce_WebApp.DAL.Context;
using ShoppEcommerce_WebApp.DAL.Reposiroties.AccountRepository;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Addresses;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Customers;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Employees;
using ShoppEcommerce_WebApp.DAL.Reposiroties.RoleRepository;
using ShoppEcommerce_WebApp.DAL.Reposiroties.Stores;
using Microsoft.EntityFrameworkCore;

namespace ShoppEcommerce_WebApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _unitOfWorkContext;
        private IAccountRepository? _accountRepository;
        private IRoleRepository? _roleRepository;
        private ICustomerRepository _customerRepository;
        private IEmployeeRepository? _employeeRepository;
        private IAddressRepository? _addressRepository;
        private IStoreRepository? _storeRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _unitOfWorkContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IAccountRepository Accounts => _accountRepository ??= new AccountRepository(_unitOfWorkContext);

        public IRoleRepository Roles => _roleRepository ??= new RoleRepository(_unitOfWorkContext);

        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_unitOfWorkContext);

        public IEmployeeRepository Employees => _employeeRepository ??= new EmployeeRepository(_unitOfWorkContext);

        public IStoreRepository Stores => _storeRepository ??= new StoreRepository(_unitOfWorkContext);

        public IAddressRepository Addresses => _addressRepository ??= new AddressRepository(_unitOfWorkContext);

        // Simple SaveChanges without transaction
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _unitOfWorkContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"SaveChanges failed: {ex.Message}", ex);
            }
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            var strategy = _unitOfWorkContext.Database.CreateExecutionStrategy();
            return await strategy.ExecuteAsync(async () =>
            {
                // Tạo một transaction scope
                await using var transaction = await _unitOfWorkContext.Database.BeginTransactionAsync();
                try
                {
                    // Thực hiện lưu thay đổi
                    var result = await _unitOfWorkContext.SaveChangesAsync();

                    // Commit transaction
                    await transaction.CommitAsync();

                    return result;
                }
                catch (Exception ex)
                {
                    // Rollback nếu có lỗi
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException($"Transaction failed: {ex.Message}", ex);
                }
            });
        }

        public int SaveChangesWithTransaction()
        {
            var strategy = _unitOfWorkContext.Database.CreateExecutionStrategy();
            return strategy.Execute(() =>
            {
                using var transaction = _unitOfWorkContext.Database.BeginTransaction();
                try
                {
                    var result = _unitOfWorkContext.SaveChanges();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InvalidOperationException($"Transaction failed: {ex.Message}", ex);
                }
            });
        }
    }
}
