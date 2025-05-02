
using ShoppEcommerce_WebApp.Common.Enums;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;

namespace ShoppEcommerce_WebApp.BLL.Roles
{
    public interface IRoleService
    {
        Task<bool> Create(EnumRoleName name);
        Task<bool> Delete(Guid id);
        Task<bool> Edit(Guid id, string name);
        Task<RoleResponse> GetRole(Guid id);
        Task<RoleResponse> GetByName(EnumRoleName name);

    }
}
