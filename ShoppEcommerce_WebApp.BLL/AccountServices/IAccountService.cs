using ShoppEcommerce_WebApp.Common.Enums;
using ShoppEcommerce_WebApp.Common.ViewModels.Pages;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;

namespace ShoppEcommerce_WebApp.BLL.AccountServices
{
    public interface IAccountService
    {
        public Task<bool> CreateAccount(AccountRequest req, bool _isAdmin);
        public Task<AccountResponse> GetById(Guid id);
        public Task<IEnumerable<AccountResponse>> GetAllAccounts();
        public Task<bool> UpdateAccount(UpdateAccountRequest req, Guid id, bool isAdmin);
        public Task<bool> UpdateAccountStatus(Guid id, EnumAccountStatus status, bool isAdmin);
        public Task<bool> DeleteAccount(Guid id);
        Task<PageResult<AccountResponse>> GetAllByPaging(int pageCurrent, int pageSize);
        Task<PageResult<AccountResponse>> GetWithParams(string? lastName, string? firstName, EnumAccountStatus? status, EnumRoleName? role, int pageCurrent, int pageSize);
    }
}
