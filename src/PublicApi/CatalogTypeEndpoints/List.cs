using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sula.Shipment.ApplicationCore.Entities;
using Sula.Shipment.ApplicationCore.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sula.Shipment.PublicApi.CatalogTypeEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ListCatalogTypesResponse>
    {
        private readonly IAsyncRepository<CatalogType> _catalogTypeRepository;
        private readonly IMapper _mapper;

        public List(IAsyncRepository<CatalogType> catalogTypeRepository,
            IMapper mapper)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("api/catalog-types")]
        [SwaggerOperation(
            Summary = "List Catalog Types",
            Description = "List Catalog Types",
            OperationId = "catalog-types.List",
            Tags = new[] { "CatalogTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListCatalogTypesResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListCatalogTypesResponse();

            var items = await _catalogTypeRepository.ListAllAsync(cancellationToken);

            response.CatalogTypes.AddRange(items.Select(_mapper.Map<CatalogTypeDto>));

            return Ok(response);
        }
    }
}
