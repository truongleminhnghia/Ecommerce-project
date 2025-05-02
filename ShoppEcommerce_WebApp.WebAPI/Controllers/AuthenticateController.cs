
using Microsoft.AspNetCore.Mvc;
using ShoppEcommerce_WebApp.BLL.AuthenticateServices;
using ShoppEcommerce_WebApp.Common.ViewModels.ApiResponse;
using ShoppEcommerce_WebApp.Common.ViewModels.Requests;

namespace ShoppEcommerce_WebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/authenticates")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticateService.Login(request.Email, request.Password);
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Message = "Login successful",
                Data = result
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authenticateService.Register(request);
            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Success = true,
                Message = "Register successful",
                Data = null
            });
        }
    }
}
