using AutoMapper;
using MediatR;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.Application.Features.Queries.GetByIdProduct;

public class GetByIdProductHandler : IRequestHandler<GetByIdProductRequest, GetByIdProductResponse>
{
    private readonly IProductElasticService productElasticService;
    public GetByIdProductHandler(IProductElasticService productElasticService)
    {
        this.productElasticService = productElasticService;
    }
    public async Task<GetByIdProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
    {
        var dto = await productElasticService.GetByIdAsync(request.ProductId);

        return new GetByIdProductResponse
        {
            Product = dto,
        };
    }
}
