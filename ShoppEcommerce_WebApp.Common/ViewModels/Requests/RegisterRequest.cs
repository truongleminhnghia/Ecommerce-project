using ShoppEcommerce_WebApp.Common.Enums;

namespace ShoppEcommerce_WebApp.Common.ViewModels.Requests
{
    public class RegisterRequest
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public EnumRoleName? RoleName { get; set; }
    }
}
