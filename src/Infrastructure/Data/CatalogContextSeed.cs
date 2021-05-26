using Microsoft.EntityFrameworkCore;
using Sula.Shipment.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sula.Shipment.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // catalogContext.Database.Migrate();
                if (!await catalogContext.CatalogBrands.AnyAsync())
                {
                    await catalogContext.CatalogBrands.AddRangeAsync(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogTypes.AnyAsync())
                {
                    await catalogContext.CatalogTypes.AddRangeAsync(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!await catalogContext.CatalogItems.AnyAsync())
                {
                    await catalogContext.CatalogItems.AddRangeAsync(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand("Azure"),
                new CatalogBrand(".NET"),
                new CatalogBrand("Visual Studio"),
                new CatalogBrand("SQL Server"),
                new CatalogBrand("Other")
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType("Mug"),
                new CatalogType("T-Shirt"),
                new CatalogType("Sheet"),
                new CatalogType("USB Memory Stick")
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem(1,1, "Dūžtančių siuntinių gabenimas", "Dūžtančių siuntinių gabenimas", 20, "http://catalogbaseurltobereplaced/images/products/item_fragile.png"),
                new CatalogItem(1,1, "Didelių gabaritų siuntų siuntimas", "Didelių gabaritų siuntų siuntimas", 15, "http://catalogbaseurltobereplaced/images/products/item_large.png"),
                new CatalogItem(1,1, "Dokumentų pasirašymui siuntimas", "Dokumentų pasirašymui siuntimas", 10, "http://catalogbaseurltobereplaced/images/products/item_signature.png")
            };
        }
    }
}
