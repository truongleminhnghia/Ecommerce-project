using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.DAL.Base;
using ShoppEcommerce_WebApp.DAL.Context;

namespace ShoppEcommerce_WebApp.DAL.Reposiroties.Addresses
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context) { }
}
}
