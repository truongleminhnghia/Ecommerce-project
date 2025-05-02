using AutoMapper;
using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.ViewModels.AuthenticateResponse;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;

namespace ShoppEcommerce_WebApp.BLL.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<AccountRequest, Account>();
            CreateMap<RegisterRequest, Account>();
            CreateMap<Account, AccountResponse>();
            CreateMap<Account, AccountCurrent>();
        }
    }
}
