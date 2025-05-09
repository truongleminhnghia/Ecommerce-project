
using AutoMapper;
using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;

namespace ShoppEcommerce_WebApp.BLL.Mappers
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            CreateMap<AddressRequest, Address>().ReverseMap();
            CreateMap<AddressUpdateRequest, Address>().ReverseMap();
            CreateMap<Address, AddressResponse>().ReverseMap();
        }
    }
}