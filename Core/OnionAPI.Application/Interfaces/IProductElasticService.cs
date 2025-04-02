using OnionAPI.Application.DTOs.Products;

namespace OnionAPI.Application.Interfaces;

public interface IProductElasticService
{
    Task<List<ProductGetDto>> GetAllAsync();
    Task<ProductGetDto> GetByIdAsync(Guid id);
    Task CreateAsync(ProductCreateDto dto, Guid productId);
    Task UpdateAsync(ProductUpdateDto dto, Guid productId);
    Task DeleteAsync(Guid productId, ProductDeleteDto dto);
}
