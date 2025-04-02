using MediatR;

namespace OnionAPI.Application.Features.Commands.UpdateProduct;

public class UpdateProductRequest : IRequest<UpdateProductResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public long Price { get; set; }
}
