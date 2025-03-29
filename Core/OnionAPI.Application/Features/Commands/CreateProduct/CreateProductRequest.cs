using MediatR;
using OnionAPI.Application.DTOs.Products;

namespace OnionAPI.Application.Features.Commands.CreateProduct;

public class CreateProductRequest : IRequest<CreateProductResponse>
{
    public ProductCreateDto Product { get; set; }
}
