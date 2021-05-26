using AutoMapper;
using Sula.Shipment.ApplicationCore.Entities;
using Sula.Shipment.PublicApi.CatalogBrandEndpoints;
using Sula.Shipment.PublicApi.CatalogItemEndpoints;
using Sula.Shipment.PublicApi.CatalogTypeEndpoints;

namespace Sula.Shipment.PublicApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogItem, CatalogItemDto>();
            CreateMap<CatalogType, CatalogTypeDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
            CreateMap<CatalogBrand, CatalogBrandDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));
        }
    }
}
