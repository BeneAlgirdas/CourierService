using Microsoft.EntityFrameworkCore;
using Sula.Shipment.ApplicationCore.Entities.OrderAggregate;
using Sula.Shipment.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Sula.Shipment.Infrastructure.Data
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(CatalogContext dbContext) : base(dbContext)
        {
        }

        public Task<Order> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Orders
                .Include(o => o.OrderItems)
                .Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
