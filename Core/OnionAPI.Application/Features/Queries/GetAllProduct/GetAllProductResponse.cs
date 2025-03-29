using OnionAPI.Application.DTOs.Products;

namespace OnionAPI.Application.Features.Queries.GetAllProduct;

public class GetAllProductResponse
{
    public List<ProductGetDto> Products { get; set; } = new();
}
