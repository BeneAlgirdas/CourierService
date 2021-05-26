﻿using MediatR;
using Sula.Shipment.ApplicationCore.Interfaces;
using Sula.Shipment.ApplicationCore.Specifications;
using Sula.Shipment.Web.ViewModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Features.OrderDetails
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetails, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailsHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderViewModel> Handle(GetOrderDetails request, CancellationToken cancellationToken)
        {
            var customerOrders = await _orderRepository.ListAsync(new CustomerOrdersWithItemsSpecification(request.UserName), cancellationToken);
            var order = customerOrders.FirstOrDefault(o => o.Id == request.OrderId);

            if (order == null)
            {
                return null;
            }

            return new OrderViewModel
            {
                OrderDate = order.OrderDate,
                OrderItems = order.OrderItems.Select(oi => new OrderItemViewModel
                {
                    PictureUrl = oi.ItemOrdered.PictureUri,
                    ProductId = oi.ItemOrdered.CatalogItemId,
                    ProductName = oi.ItemOrdered.ProductName,
                    UnitPrice = oi.UnitPrice,
                    Units = oi.Units
                }).ToList(),
                OrderNumber = order.Id,
                ShippingAddress = order.ShipToAddress,
                Total = order.Total(),

                CheckoutMethod = order.CheckoutMethod,
                CourierArrivalTime = order.CourierArrivalTime,
                RecipientName = order.RecipientName,
                RecipientSurname = order.RecipientSurname,
                RecipientPhoneNo = order.RecipientPhoneNo
            };
        }
    }
}