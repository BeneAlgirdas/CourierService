using System.ComponentModel.DataAnnotations;

namespace Sula.Shipment.Web.ViewModels.Manage
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        public string StatusMessage { get; set; }
    }
}
