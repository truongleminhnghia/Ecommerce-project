using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppEcommerce_WebApp.BLL.AccountServices;
using ShoppEcommerce_WebApp.Common.ViewModels.ApiResponse;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;

namespace ShoppEcommerce_WebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/publics")]
    public class PublicController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public PublicController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] AccountRequest request)
        {
            var result = await _accountService.CreateAccount(request, false);

            if (result)
            {
                var response = new ApiResponse
                {
                    Code = StatusCodes.Status201Created,
                    Success = true,
                    Message = "Account created successfully.",
                    Data = request
                };
                return response;
            }
            else
            {
                var response = new ApiResponse
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Message = "An error occurred while creating the account.",
                    Data = null
                };
                return response;
            }
        }
    }
}
