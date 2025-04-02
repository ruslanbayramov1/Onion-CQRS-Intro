using AutoMapper;
using MediatR;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.Application.Features.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
{
    private readonly IProductElasticService productElasticService;
    private readonly IProductPostgreService productPostgreService;
    private readonly IMapper mapper;
    public UpdateProductHandler(IProductElasticService productElasticService, IProductPostgreService productPostgreService, IMapper mapper)
    {
        this.productElasticService = productElasticService;
        this.productPostgreService = productPostgreService;
        this.mapper = mapper;
    }

    public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var dto = mapper.Map<ProductUpdateDto>(request);
        dto.UpdatedAt = DateTime.UtcNow;

        await productPostgreService.UpdateAsync(request.Id, dto);
        await productElasticService.UpdateAsync(dto, request.Id);

        return new();
    }
}
