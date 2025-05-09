
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppEcommerce_WebApp.Common.Entities
{
    [Table("address")]
    public class Address : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("street", TypeName = "nvarchar(300)")]
        public string? Street { get; set; }

        [Column("ward", TypeName = "nvarchar(100)")]
        [Required]
        public string? Ward { get; set; }

        [Column("district", TypeName = "nvarchar(100)")]
        [Required]
        public string? District { get; set; }

        [Column("city", TypeName = "nvarchar(100)")]
        [Required]
        public string? City { get; set; }

        [Column("country", TypeName = "nvarchar(100)")]
        [Required]
        public string? Country { get; set; }

        [Column("address_detail", TypeName = "nvarchar(300)")]
        public string? AddressDetail { get; set; }

        [Column("customer_id")]
        public Guid? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.OrderAddresses))]
        public Customer? Customer { get; set; }

        public Employee? EmployeeHome { get; set; }
        public Employee? EmployeeWork { get; set; }
    }
}
