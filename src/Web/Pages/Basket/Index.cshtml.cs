using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sula.Shipment.ApplicationCore.Interfaces;
using Sula.Shipment.Infrastructure.Identity;
using Sula.Shipment.Web.Interfaces;
using Sula.Shipment.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Pages.Basket
{
    public class IndexModel : PageModel
    {
        public List<SelectListItem> CheckoutMethods = new List<SelectListItem>
        {
            new SelectListItem {Value = "Swedbank", Text = "Swedbank" },
            new SelectListItem {Value = "Luminor", Text = "Luminor" },
            new SelectListItem {Value = "Šiaulių bankas", Text = "Šiaulių bankas" },
            new SelectListItem {Value = "Citadele", Text = "Citadele" },
            new SelectListItem {Value = "Credit Card", Text = "Credit Card" }
        };

        private readonly IBasketService _basketService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _username = null;
        private readonly IBasketViewModelService _basketViewModelService;

        public IndexModel(IBasketService basketService,
            IBasketViewModelService basketViewModelService,
            SignInManager<ApplicationUser> signInManager)
        {
            _basketService = basketService;
            _signInManager = signInManager;
            _basketViewModelService = basketViewModelService;
        }

        public BasketViewModel BasketModel { get; set; } = new BasketViewModel();

        public async Task OnGet()
        {
            await SetBasketModelAsync();
        }

        public async Task<IActionResult> OnPost(CatalogItemViewModel productDetails)
        {
            if (productDetails?.Id == null)
            {
                return RedirectToPage("/Index");
            }
            await SetBasketModelAsync();

            await _basketService.AddItemToBasket(BasketModel.Id, productDetails.Id, productDetails.Price);

            await SetBasketModelAsync();

            return RedirectToPage();
        }

        public async Task OnPostUpdate(IEnumerable<BasketItemViewModel> items, string checkoutMethod, string courierArrivalTime, string recipientName, string recipientSurname, string recipientAddress, string recipientPhoneNo)
        {
            await SetBasketModelAsync();

            if (!ModelState.IsValid)
            {
                return;
            }

            var updateModel = items.ToDictionary(b => b.Id.ToString(), b => b.Quantity);
            await _basketService.SetQuantities(BasketModel.Id, updateModel);
            await _basketService.SetCheckoutProperties(BasketModel.Id, checkoutMethod, courierArrivalTime, recipientName, recipientSurname, recipientAddress, recipientPhoneNo);

            await SetBasketModelAsync();
        }

        private async Task SetBasketModelAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(User.Identity.Name);
            }
            else
            {
                GetOrSetBasketCookieAndUserName();
                BasketModel = await _basketViewModelService.GetOrCreateBasketForUser(_username);
            }
        }

        private void GetOrSetBasketCookieAndUserName()
        {
            if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            {
                _username = Request.Cookies[Constants.BASKET_COOKIENAME];
            }
            if (_username != null) return;

            _username = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(10);
            Response.Cookies.Append(Constants.BASKET_COOKIENAME, _username, cookieOptions);
        }
    }
}
