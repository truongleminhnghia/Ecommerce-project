using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;

namespace ShoppEcommerce_WebApp.BLL.Addresses
{
    public interface IAddressService
    {
        Task<bool> AddAddress(AddressRequest request);
        Task<AddressResponse> GetById(Guid id);
        Task<IEnumerable<AddressResponse>> GetAll();
        Task<IEnumerable<AddressResponse>> GetByAccount(Guid id);
        Task<bool> UpdateAddress(Guid id, AddressUpdateRequest request);
        Task<bool> DeleteAddress(Guid id);
    }
}