using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.Enums;
using ShoppEcommerce_WebApp.Common.ViewModels.Pages;
using ShoppEcommerce_WebApp.DAL.Base;

namespace ShoppEcommerce_WebApp.DAL.Reposiroties.AccountRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account?> GetByEmail(string email);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(Account account);
        Task<IEnumerable<Account>> FindAll();
        Task<PageResult<Account>> FindByPaging(int pageCurrent, int pageSize);
        Task<IEnumerable<Account>> FindWithParams(string? lastName, string? firstName, EnumAccountStatus? status, EnumRoleName? role);
    }
}
