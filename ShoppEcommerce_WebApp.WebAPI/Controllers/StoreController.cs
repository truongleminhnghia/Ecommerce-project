
using Microsoft.AspNetCore.Mvc;
using ShoppEcommerce_WebApp.BLL.Stores;
using ShoppEcommerce_WebApp.Common.ViewModels.ApiResponse;

namespace ShoppEcommerce_WebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/stores")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly ILogger<StoreController> _logger;

        public StoreController(IStoreService storeService, ILogger<StoreController> logger)
        {
            _storeService = storeService;
            _logger = logger;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var store = await _storeService.GetById(id);
            if (store == null)
            {
                _logger.LogWarning($"Store with id {id} not found.");
                return NotFound(new ApiResponse
                {
                    Code = StatusCodes.Status404NotFound,
                    Success = false,
                    Message = "Store not found",
                    Data = null
                });
            }
            _logger.LogInformation($"Store with id {id} retrieved successfully.");
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Message = "Store retrieved successfully",
                Data = store
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page_current = 1, [FromQuery] int page_size = 10)
        {
            var stores = await _storeService.GetAllStores(page_current, page_size);
            // if (stores == null || !stores.Any())
            // {
            //     _logger.LogWarning("No stores found.");
            //     return NotFound(new ApiResponse
            //     {
            //         Code = StatusCodes.Status404NotFound,
            //         Success = false,
            //         Message = "No stores found",
            //         Data = null
            //     });
            // }
            _logger.LogInformation("Stores retrieved successfully.");
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Message = "Stores retrieved successfully",
                Data = stores
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _storeService.DeleteStore(id);
            if (!result)
            {
                _logger.LogWarning($"Failed to delete store with id {id}.");
                return NotFound(new ApiResponse
                {
                    Code = StatusCodes.Status404NotFound,
                    Success = false,
                    Message = "Store not found",
                    Data = null
                });
            }
            _logger.LogInformation($"Store with id {id} deleted successfully.");
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Message = "Store deleted successfully",
                Data = null
            });
        }
    }
}