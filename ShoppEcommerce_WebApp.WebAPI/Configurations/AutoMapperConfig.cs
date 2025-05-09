using ShoppEcommerce_WebApp.BLL.Mappers;

namespace ShoppEcommerce_WebApp.WebAPI.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AccountMapper));
            services.AddAutoMapper(typeof(AddressMapper));
            services.AddAutoMapper(typeof(StoreMapper));
            services.AddAutoMapper(typeof(RoleMapper));
            return services;
        }
    }
}
