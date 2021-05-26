using Sula.Shipment.ApplicationCore.Entities.OrderAggregate;
using System;
using System.Threading.Tasks;

namespace Sula.Shipment.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int id, Address address, string checkoutMethod, DateTime courierArrivalTime, string recipientName, string recipientSurname, string recipientPhoneNo);
    }
}
