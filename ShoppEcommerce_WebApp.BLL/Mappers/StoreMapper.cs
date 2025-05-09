
using AutoMapper;
using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;

namespace ShoppEcommerce_WebApp.BLL.Mappers
{
    public class StoreMapper : Profile
    {
        public StoreMapper()
        {
            CreateMap<Store, StoreResponse>().ReverseMap();
            CreateMap<Store, StoreRequest>().ReverseMap();
        }
    }
}