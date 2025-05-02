using ShoppEcommerce_WebApp.Common.Enums;

namespace ShoppEcommerce_WebApp.Common.ViewModels.AuthenticateResponse
{
    public class AccountCurrent
    {
        public string? Email { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        // public RoleResponse? Role { get; set; }
        public EnumAccountStatus? EnumAccountStatus { get; set; }
    }
}
