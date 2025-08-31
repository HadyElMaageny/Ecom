using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;

namespace Ecom.API.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductDto>().ForMember(x => x.CategoryName, y => y.MapFrom(x => x.Category.Name))
            .ReverseMap();
        CreateMap<Photo, PhotoDto>().ReverseMap();
        CreateMap<AddProductDto, Product>()
            .ForMember(p => p.Photos, apd => apd.Ignore())
            .ReverseMap();
        CreateMap<UpdateProductDto, Product>()
            .ForMember(p => p.Photos, upd => upd.Ignore())
            .ReverseMap();
    }
}