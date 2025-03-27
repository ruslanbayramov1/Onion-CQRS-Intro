using AutoMapper;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductUpdateDto, Product>();
    }
}
