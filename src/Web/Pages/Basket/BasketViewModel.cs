using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sula.Shipment.Web.Pages.Basket
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public string BuyerId { get; set; }

        [Required]
        [Display(Name = "Checkout Method")]
        public string CheckoutMethod { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Courier Arrival Time")]
        public DateTime CourierArrivalTime { get; set; }

        [Required]
        [Display(Name = "Recipient Name")]
        public string RecipientName { get; set; }

        [Required]
        [Display(Name = "Recipient Surname")]
        public string RecipientSurname { get; set; }

        [Required]
        [Display(Name = "Recipient Address")]
        public string RecipientAddress { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Recipient Phone No")]
        public string RecipientPhoneNo { get; set; }


        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }
    }
}
