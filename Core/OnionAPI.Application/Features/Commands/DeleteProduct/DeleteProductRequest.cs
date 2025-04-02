using MediatR;

namespace OnionAPI.Application.Features.Commands.DeleteProduct;

public class DeleteProductRequest : IRequest<DeleteProductResponse>
{
    public Guid Id { get; set; }
}
