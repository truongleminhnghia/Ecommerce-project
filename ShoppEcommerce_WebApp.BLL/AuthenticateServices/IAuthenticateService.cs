using ShoppEcommerce_WebApp.Common.ViewModels.AuthenticateResponse;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;

namespace ShoppEcommerce_WebApp.BLL.AuthenticateServices
{
    public interface IAuthenticateService
    {
        public Task<AuthenticateResponse> Login(string email, string password);
        public Task<bool> Register(RegisterRequest request);
    }
}
