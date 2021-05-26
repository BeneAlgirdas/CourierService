using Sula.Shipment.ApplicationCore.Entities.OrderAggregate;
using System;
using System.Collections.Generic;

namespace Sula.Shipment.Web.ViewModels
{
    public class OrderViewModel
    {
        private const string DEFAULT_STATUS = "Pending";

        public int OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Total { get; set; }
        public string Status => DEFAULT_STATUS;
        public Address ShippingAddress { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();

        public string RecipientName { get; set; }
        public string CheckoutMethod { get; set; }
        public DateTime CourierArrivalTime { get; set; }
        public string RecipientSurname { get; set; }
        public string RecipientPhoneNo { get; set; }
    }
}
