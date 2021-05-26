using Microsoft.AspNetCore.Mvc;

namespace Sula.Shipment.PublicApi.CatalogItemEndpoints
{
    public class DeleteCatalogItemRequest : BaseRequest 
    {
        //[FromRoute]
        public int CatalogItemId { get; set; }
    }
}
