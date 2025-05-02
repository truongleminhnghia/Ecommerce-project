using ShoppEcommerce_WebApp.Common.Entities;
using ShoppEcommerce_WebApp.DAL.Base;
using ShoppEcommerce_WebApp.DAL.Context;

namespace ShoppEcommerce_WebApp.DAL.Reposiroties.Stores
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext conetext) : base(conetext)
        {
            
        }
    }
}
