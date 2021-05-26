using Sula.Shipment.Web.Pages.Basket;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    }
}
