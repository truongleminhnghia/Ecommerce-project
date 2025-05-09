
using ShoppEcommerce_WebApp.Common.ViewModels.Pages;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;

namespace ShoppEcommerce_WebApp.BLL.Stores
{
    public interface IStoreService
    {
        Task<bool> CreateStore(StoreRequest request);
        Task<StoreResponse> GetById(Guid id);
        Task<PageResult<StoreResponse>> GetAllStores(int pageCurrent, int pageSize);
        Task<bool> UpdateStore(Guid id, StoreUpdateReqest request);
        Task<bool> DeleteStore(Guid id);
    }
}