using MediatR;

namespace OnionAPI.Application.Features.Queries.GetByIdProduct;

public class GetByIdProductRequest : IRequest<GetByIdProductResponse>
{
    public Guid ProductId { get; set; }
}
