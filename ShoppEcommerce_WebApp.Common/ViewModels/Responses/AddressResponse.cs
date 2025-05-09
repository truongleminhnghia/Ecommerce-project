

using ShoppEcommerce_WebApp.Common.Entities;

namespace ShoppEcommerce_WebApp.Common.ViewModels.Responses
{
    public class AddressResponse
    {
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? Ward { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? AddressDetail { get; set; }
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public Employee? EmployeeHome { get; set; }
        public Employee? EmployeeWork { get; set; }
    }
}