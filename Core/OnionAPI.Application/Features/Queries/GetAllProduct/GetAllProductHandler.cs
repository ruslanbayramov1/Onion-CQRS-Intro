using MediatR;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.Application.Features.Queries.GetAllProduct;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
{
    private readonly IProductElasticService productElasticService;
    public GetAllProductHandler(IProductElasticService productElasticService)
    {
        this.productElasticService = productElasticService;
    }
    
    public async Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var data = await productElasticService.GetAllAsync();

        return new GetAllProductResponse
        {
            Products = data,
        };
    }
}
