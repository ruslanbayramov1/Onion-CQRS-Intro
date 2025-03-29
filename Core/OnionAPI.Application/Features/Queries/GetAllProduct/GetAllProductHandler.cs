using MediatR;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.Application.Features.Queries.GetAllProduct;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
{
    private readonly IProductService productService;
    public GetAllProductHandler(IProductService productService)
    {
        this.productService = productService;
    }
    
    public async Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var data = await productService.GetAllAsync();

        return new GetAllProductResponse
        {
            Products = data,
        };
    }
}
