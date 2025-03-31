using MediatR;

namespace OnionAPI.Application.Features.Commands.CreateProduct;

public class CreateProductRequest : IRequest<CreateProductResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public long Price { get; set; }
}
