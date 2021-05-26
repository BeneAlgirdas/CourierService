using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sula.Shipment.ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task TransferBasketAsync(string anonymousId, string userName);
        Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity = 1);
        Task SetQuantities(int basketId, Dictionary<string, int> quantities);
        Task DeleteBasketAsync(int basketId);
        Task SetCheckoutProperties(int basketId, string checkoutMethod, string courierArrivalTime, string recipientName, string recipientSurname, string recipientAddress, string recipientPhoneNo);
    }
}
