using Sula.Shipment.ApplicationCore.Interfaces;

namespace Sula.Shipment.ApplicationCore.Services
{
    public class UriComposer : IUriComposer
    {
        private readonly CatalogSettings _catalogSettings;

        public UriComposer(CatalogSettings catalogSettings) => _catalogSettings = catalogSettings;

        public string ComposePicUri(string uriTemplate)
        {
            return uriTemplate.Replace("http://catalogbaseurltobereplaced", _catalogSettings.CatalogBaseUrl);
        }
    }
}
