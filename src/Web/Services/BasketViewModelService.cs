using Sula.Shipment.ApplicationCore.Entities;
using Sula.Shipment.ApplicationCore.Entities.BasketAggregate;
using Sula.Shipment.ApplicationCore.Interfaces;
using Sula.Shipment.ApplicationCore.Specifications;
using Sula.Shipment.Web.Interfaces;
using Sula.Shipment.Web.Pages.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IAsyncRepository<CatalogItem> _itemRepository;

        public BasketViewModelService(IAsyncRepository<Basket> basketRepository,
            IAsyncRepository<CatalogItem> itemRepository,
            IUriComposer uriComposer)
        {
            _basketRepository = basketRepository;
            _uriComposer = uriComposer;
            _itemRepository = itemRepository;
        }

        public async Task<BasketViewModel> GetOrCreateBasketForUser(string userName)
        {
            var basketSpec = new BasketWithItemsSpecification(userName);
            var basket = (await _basketRepository.FirstOrDefaultAsync(basketSpec));

            if (basket == null)
            {
                return await CreateBasketForUser(userName);
            }
            return await CreateViewModelFromBasket(basket);
        }

        private async Task<BasketViewModel> CreateViewModelFromBasket(Basket basket)
        {
            var viewModel = new BasketViewModel
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = await GetBasketItems(basket.Items),
                CheckoutMethod = basket.CheckoutMethod,
                CourierArrivalTime = basket.CourierArrivalTime == DateTime.MinValue ? DateTime.Now : basket.CourierArrivalTime,
                RecipientName = basket.RecipientName,
                RecipientSurname = basket.RecipientSurname,
                RecipientAddress = basket.RecipientAddress,
                RecipientPhoneNo = basket.RecipientPhoneNo
            };
            
            return viewModel;
        }

        private async Task<BasketViewModel> CreateBasketForUser(string userId)
        {
            var basket = new Basket(userId);
            await _basketRepository.AddAsync(basket);

            return new BasketViewModel()
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
                CourierArrivalTime = DateTime.Now
            };
        }

        private async Task<List<BasketItemViewModel>> GetBasketItems(IReadOnlyCollection<BasketItem> basketItems)
        {
            var catalogItemsSpecification = new CatalogItemsSpecification(basketItems.Select(b => b.CatalogItemId).ToArray());
            var catalogItems = await _itemRepository.ListAsync(catalogItemsSpecification);

            var items = basketItems.Select(basketItem =>
            {
                var catalogItem = catalogItems.First(c => c.Id == basketItem.CatalogItemId);

                var basketItemViewModel = new BasketItemViewModel
                {
                    Id = basketItem.Id,
                    UnitPrice = basketItem.UnitPrice,
                    Quantity = basketItem.Quantity,
                    CatalogItemId = basketItem.CatalogItemId,
                    PictureUrl = _uriComposer.ComposePicUri(catalogItem.PictureUri),
                    ProductName = catalogItem.Name
                };
                return basketItemViewModel;
            }).ToList();

            return items;
        }
    }
}
