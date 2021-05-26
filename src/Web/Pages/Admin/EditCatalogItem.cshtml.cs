using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sula.Shipment.ApplicationCore.Constants;
using Sula.Shipment.Web.Interfaces;
using Sula.Shipment.Web.ViewModels;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Pages.Admin
{
    [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS)]
    public class EditCatalogItemModel : PageModel
    {
        private readonly ICatalogItemViewModelService _catalogItemViewModelService;

        public EditCatalogItemModel(ICatalogItemViewModelService catalogItemViewModelService)
        {
            _catalogItemViewModelService = catalogItemViewModelService;
        }

        [BindProperty]
        public CatalogItemViewModel CatalogModel { get; set; } = new CatalogItemViewModel();

        public void OnGet(CatalogItemViewModel catalogModel)
        {
            CatalogModel = catalogModel;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _catalogItemViewModelService.UpdateCatalogItem(CatalogModel);
            }

            return RedirectToPage("/Admin/Index");
        }
    }
}
