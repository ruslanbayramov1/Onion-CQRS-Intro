using MediatR;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.Application.Features.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductService productService;
    public CreateProductHandler(IProductService productService)
    {
        this.productService = productService;
    }
    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var productId = await productService.AddAsync(request.Product);

        return new CreateProductResponse
        {
            ProductId = productId,
        };
    }
}
