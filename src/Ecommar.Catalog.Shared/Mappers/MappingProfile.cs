using AutoMapper;
using Ecommar.Catalog.Shared.DTOs;
using Ecommar.Catalog.Shared.Models;
using MongoDB.Bson;

namespace Ecommar.Catalog.Shared.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => IsValidObjectId(src.ProductId) ? src.ProductId : null));


        CreateMap<ProductReview, ProductReviewDto>().ReverseMap();
        CreateMap<ProductSpecification, ProductSpecificationDto>().ReverseMap();

        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => IsValidObjectId(src.ProductId) ? src.ProductId : null));
    }

    private bool IsValidObjectId(string? objectId)
    {
        return ObjectId.TryParse(objectId, out _);
    }

}