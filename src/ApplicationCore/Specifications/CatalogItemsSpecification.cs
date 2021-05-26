using Ardalis.Specification;
using Sula.Shipment.ApplicationCore.Entities;
using System;
using System.Linq;

namespace Sula.Shipment.ApplicationCore.Specifications
{
    public class CatalogItemsSpecification : Specification<CatalogItem>
    {
        public CatalogItemsSpecification(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
