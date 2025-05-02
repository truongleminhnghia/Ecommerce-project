using ShoppEcommerce_WebApp.BLL.Mappers;

namespace ShoppEcommerce_WebApp.WebAPI.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AccountMapper));
            return services;
        }
    }
}
