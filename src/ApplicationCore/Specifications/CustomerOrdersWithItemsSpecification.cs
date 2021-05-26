using Ardalis.Specification;
using Sula.Shipment.ApplicationCore.Entities.OrderAggregate;

namespace Sula.Shipment.ApplicationCore.Specifications
{
    public class CustomerOrdersWithItemsSpecification : Specification<Order>
    {
        public CustomerOrdersWithItemsSpecification(string buyerId)
        {
            Query.Where(o => o.BuyerId == buyerId)
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.ItemOrdered);
        }
    }
}
