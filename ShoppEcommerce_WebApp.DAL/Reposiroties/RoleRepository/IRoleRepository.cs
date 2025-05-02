using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.Enums;
using ShoppEcommerce_WebApp.DAL.Base;

namespace ShoppEcommerce_WebApp.DAL.Reposiroties.RoleRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role?> GetByName(EnumRoleName name);

    }
}
