using Sula.Shipment.Web.ViewModels;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Interfaces
{
    public interface ICatalogItemViewModelService
    {
        Task UpdateCatalogItem(CatalogItemViewModel viewModel);
    }
}
