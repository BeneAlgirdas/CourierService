namespace Sula.Shipment.PublicApi.CatalogItemEndpoints
{
    public class GetByIdCatalogItemRequest : BaseRequest 
    {
        public int CatalogItemId { get; set; }
    }
}
