
using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppEcommerce_WebApp.BLL.AccountServices;
using ShoppEcommerce_WebApp.Common.Exceptions;
using ShoppEcommerce_WebApp.Common.ViewModels.Pages;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;
using ShoppEcommerce_WebApp.Common.ViewModels.Responses;
using ShoppEcommerce_WebApp.DAL;

namespace ShoppEcommerce_WebApp.BLL.Stores
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly ILogger<StoreService> _logger;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper, IAccountService accountService, ILogger<StoreService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _accountService = accountService;
        }

        public Task<bool> CreateStore(StoreRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteStore(Guid id)
        {
            try
            {
                var store = await _unitOfWork.Stores.GetByIdAsync(id);
                if (store == null) throw new AppException(ErrorCode.NOT_FOUND);
                await _unitOfWork.Stores.DeleteAsync(store);
                await _unitOfWork.SaveChangesWithTransactionAsync();
                _logger.LogInformation("Delete store successfully with id {Id}", id);
                return true;
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "AppException occurred: {Message}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                throw new AppException(ErrorCode.INTERNAL_SERVER_ERROR);
            }
        }

        public async Task<PageResult<StoreResponse>> GetAllStores(int pageCurrent, int pageSize)
        {
            try
            {
                var result = await _unitOfWork.Stores.GetAllAsync();
                if (result == null) throw new AppException(ErrorCode.LIST_EMPTY);
                var pagedResult = result.Skip((pageCurrent - 1) * pageSize).Take(pageSize).ToList();
                var total = result.Count();
                var data = _mapper.Map<List<StoreResponse>>(pagedResult);
                if (data == null || !data.Any()) throw new AppException(ErrorCode.LIST_EMPTY);
                var pageResult = new PageResult<StoreResponse>(data, pageSize, pageCurrent, total);
                return pageResult;
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "AppException occurred: {Message}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                throw new AppException(ErrorCode.INTERNAL_SERVER_ERROR);
            }
        }

        public async Task<StoreResponse> GetById(Guid id)
        {
            try
            {
                var store = await _unitOfWork.Stores.GetByIdAsync(id);
                if (store == null) throw new AppException(ErrorCode.NOT_FOUND);
                var storeResponse = _mapper.Map<StoreResponse>(store);
                _logger.LogInformation("Get store information successfully with id {Id}", id);
                return storeResponse;
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "AppException occurred: {Message}", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);
                throw new AppException(ErrorCode.INTERNAL_SERVER_ERROR);
            }
        }

        public Task<bool> UpdateStore(Guid id, StoreUpdateReqest request)
        {
            throw new NotImplementedException();
        }
    }
}