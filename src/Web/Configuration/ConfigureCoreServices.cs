using Sula.Shipment.ApplicationCore.Interfaces;
using Sula.Shipment.ApplicationCore.Services;
using Sula.Shipment.Infrastructure.Data;
using Sula.Shipment.Infrastructure.Logging;
using Sula.Shipment.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sula.Shipment.Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddSingleton<IUriComposer>(new UriComposer(configuration.Get<CatalogSettings>()));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
