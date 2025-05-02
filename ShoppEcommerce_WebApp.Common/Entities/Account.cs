using Microsoft.EntityFrameworkCore;
using ShoppEcommerce_WebApp.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppEcommerce_WebApp.Common.Entities
{
    [Table("account")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(EnumAccountStatus))]
    public class Account : BaseEntity
    {
        [Key]
        [Column("account_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("email", TypeName = "nvarchar(300)")]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("last_name", TypeName = "nvarchar(300)")]
        public string? LastName { get; set; }

        [Column("first_name", TypeName = "nvarchar(300)")]
        public string? FirstName { get; set; }

        [Column("password", TypeName = "nvarchar(100)")]
        public string? Password { get; set; }

        [Column("phone", TypeName = "nvarchar(15)")]
        public string? Phone { get; set; }

        [Column("avatar", TypeName = "nvarchar(500)")]
        public string? Avatar { get; set; }

        [ForeignKey("Role")]
        [Column("role_id")]
        [Required]
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }

        [EnumDataType(typeof(EnumAccountStatus))]
        [Column("account_status", TypeName = "nvarchar(50)")]
        [Required]
        public EnumAccountStatus? EnumAccountStatus { get; set; }

        [EnumDataType(typeof(EnumGender))]
        [Column("gender", TypeName = "nvarchar(50)")]
        [Required]
        public EnumGender Gender { get; set; }

        [Column("date_of_birth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }

        [Column("employee_id")]
        public Guid? EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employee.Account))]
        public Employee? Employee { get; set; }

        [Column("customer_id")]
        public Guid? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.Account))]
        public Customer? Customer { get; set; }
    }
}
