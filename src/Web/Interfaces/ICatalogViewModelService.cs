using Microsoft.AspNetCore.Mvc.Rendering;
using Sula.Shipment.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Services
{
    public interface ICatalogViewModelService
    {
        Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId);
        Task<IEnumerable<SelectListItem>> GetBrands();
        Task<IEnumerable<SelectListItem>> GetTypes();
    }
}
