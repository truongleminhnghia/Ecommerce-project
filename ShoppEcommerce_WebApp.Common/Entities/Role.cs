
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ShoppEcommerce_WebApp.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace ShoppEcommerce_WebApp.Common.Entities
{
    [Table("role")]
    [Index(nameof(RoleName))]
    public class Role
    {
        [Key]
        [Column("role_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [EnumDataType(typeof(EnumRoleName))]
        [Column("role_name", TypeName = "nvarchar(50)")]
        public EnumRoleName RoleName { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
