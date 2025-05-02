
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ShoppEcommerce_WebApp.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace ShoppEcommerce_WebApp.Common.Entities
{
    [Table("store")]
    [Index(nameof(StoreName))]
    [Index(nameof(OwnerId))]
    [Index(nameof(StatusActice))]
    public class Store : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("store_id")]
        public Guid Id { get; set; }

        [Required]
        [Column("store_name", TypeName = "nvarchar(200)")]
        public string? StoreName { get; set; }

        [Column("description", TypeName = "nvarchar(1000)")]
        public string? Description { get; set; }

        [Column("owner_id")]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Account? Owner { get; set; }

        [Column("address_id")]
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address? Address { get; set; }

        [Column("phone_number", TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }

        [Column("email", TypeName = "varchar(100)")]
        public string? Email { get; set; }

        [EnumDataType(typeof(StatusActice))]
        [Column("is_active", TypeName = "nvarchar(50)")]
        [Required]
        public StatusActice? StatusActice { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
