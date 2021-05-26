using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Sula.Shipment.Web.Areas.Identity.IdentityHostingStartup))]
namespace Sula.Shipment.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}