using STDShop.Data.Infrastructure;
using STDShop.Model.Models;

namespace STDShop.Data.Repositories
{
    public interface IOrderDetailRepository :  IRepository<OrderDetail>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}