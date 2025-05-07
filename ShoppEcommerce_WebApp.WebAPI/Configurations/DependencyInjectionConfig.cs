using ShoppEcommerce_WebApp.BLL.HashPasswords;
using ShoppEcommerce_WebApp.BLL.JWTServices;
using ShoppEcommerce_WebApp.DAL.Base;
using ShoppEcommerce_WebApp.DAL.Reposiroties.AccountRepository;
using ShoppEcommerce_WebApp.DAL;
using ShoppEcommerce_WebApp.DAL.Reposiroties.RoleRepository;
using ShoppEcommerce_WebApp.BLL.Roles;
using ShoppEcommerce_WebApp.BLL.AuthenticateServices;
using ShoppEcommerce_WebApp.BLL.AccountServices;

namespace ShoppEcommerce_WebApp.WebAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
}
