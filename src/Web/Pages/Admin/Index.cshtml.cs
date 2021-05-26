using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sula.Shipment.ApplicationCore.Constants;
using Sula.Shipment.Web.Extensions;
using Sula.Shipment.Web.Services;
using Sula.Shipment.Web.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Sula.Shipment.Web.Pages.Admin
{
    [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS)]
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
           
        }
    }
}
