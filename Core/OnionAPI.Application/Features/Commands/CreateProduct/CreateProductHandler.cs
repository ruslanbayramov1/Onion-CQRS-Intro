using AutoMapper;
using MediatR;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.Application.Features.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductPostgreService productPostgreService;
    private readonly IProductElasticService productElasticService;
    private readonly IMapper mapper;
    public CreateProductHandler(IProductPostgreService productService, IProductElasticService productElasticService, IMapper mapper)
    {
        this.productPostgreService = productService;
        this.productElasticService = productElasticService;
        this.mapper = mapper;
    }
    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var dto = mapper.Map<ProductCreateDto>(request);
        dto.CreatedAt = DateTime.UtcNow;

        var productId = await productPostgreService.CreateAsync(dto);
        await productElasticService.CreateAsync(dto, productId);

        return new CreateProductResponse
        {
            ProductId = productId,
        };
    }
}
