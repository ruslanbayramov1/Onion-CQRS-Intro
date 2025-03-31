using OnionAPI.Application.DTOs.Products;

namespace OnionAPI.Application.Interfaces;

public interface IProductPostgreService
{
    Task<List<ProductGetDto>> GetAllAsync();
    Task<ProductGetDto> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(ProductCreateDto dto);
    Task UpdateAsync(Guid id, ProductUpdateDto dto);
    Task DeleteAsync(Guid id);
}
