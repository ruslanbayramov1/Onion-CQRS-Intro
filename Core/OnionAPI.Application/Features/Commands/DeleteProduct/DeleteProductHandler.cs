using AutoMapper;
using MediatR;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.Application.Features.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IProductElasticService productElasticService;
    private readonly IProductPostgreService productPostgreService;
    public DeleteProductHandler(IProductElasticService productElasticService, IProductPostgreService productPostgreService, IMapper mapper)
    {
        this.productElasticService = productElasticService;
        this.productPostgreService = productPostgreService;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        ProductDeleteDto dto = new ProductDeleteDto
        {
            DeletedAt = DateTime.UtcNow,
            IsDeleted = true,
        };

        await productPostgreService.DeleteAsync(request.Id, dto);
        await productElasticService.DeleteAsync(request.Id, dto);

        return new();
    }
}
