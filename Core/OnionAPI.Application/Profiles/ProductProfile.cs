using AutoMapper;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Features.Commands.CreateProduct;
using OnionAPI.Application.Features.Commands.UpdateProduct;
using OnionAPI.Domain.Entities;

namespace OnionAPI.Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductDeleteDto, Product>().ReverseMap();

        CreateMap<CreateProductRequest, ProductCreateDto>();
        CreateMap<UpdateProductRequest, ProductUpdateDto>();
    }
}
