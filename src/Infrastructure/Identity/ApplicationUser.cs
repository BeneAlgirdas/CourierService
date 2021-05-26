using Microsoft.AspNetCore.Identity;

namespace Sula.Shipment.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
