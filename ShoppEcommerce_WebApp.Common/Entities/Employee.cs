
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppEcommerce_WebApp.Common.Entities
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("employee_id")]
        public Guid Id { get; set; }

        [Required]
        [Column("ref_code", TypeName = "VARCHAR(10)")]
        public string? RefCode { get; set; }

        [Required]
        [Column("home_address_id")]
        public Guid? HomeAddressId { get; set; }

        [Required]
        [Column("work_address_id")]
        public Guid? WorkAddressId { get; set; }

        [ForeignKey(nameof(HomeAddressId))]
        [InverseProperty("EmployeeHome")]
        public Address? HomeAddress { get; set; }

        [ForeignKey(nameof(WorkAddressId))]
        [InverseProperty("EmployeeWork")]
        public Address? WorkAddress { get; set; }

        [InverseProperty(nameof(Account.Employee))]
        public Account? Account { get; set; }

        [Required]
        [Column("store_id")]
        public Guid? StoreId { get; set; }

        [ForeignKey(nameof(StoreId))]
        public Store? Store { get; set; }

    }
}
