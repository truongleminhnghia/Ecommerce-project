
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppEcommerce_WebApp.Common.Entities
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public Guid Id { get; set; }

        [InverseProperty(nameof(Account.Customer))]
        public Account? Account { get; set; }

        [Column("home_address")]
        public Guid? HomeAddressId { get; set; }

        [ForeignKey(nameof(HomeAddressId))]
        public Address? HomeAddress { get; set; }

        public ICollection<Address> OrderAddresses { get; set; } = new List<Address>();
    }
}
