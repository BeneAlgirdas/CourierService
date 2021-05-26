using Sula.Shipment.ApplicationCore.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace Sula.Shipment.ApplicationCore.Interfaces
{

    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
