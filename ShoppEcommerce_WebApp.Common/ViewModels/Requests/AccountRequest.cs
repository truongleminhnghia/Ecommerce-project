using ShoppEcommerce_WebApp.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShoppEcommerce_WebApp.Common.ViewModels.Requests
{
    public class AccountRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public EnumRoleName RoleName { get; set; }
        public EnumAccountStatus? EnumAccountStatus { get; set; }
        public EnumGender Gender { get; set; }
    }
}
