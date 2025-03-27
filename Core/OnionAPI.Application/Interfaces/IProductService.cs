using OnionAPI.Application.DTOs.Products;

namespace OnionAPI.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductGetDto>> GetAllAsync();
    Task<ProductGetDto> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(ProductCreateDto dto);
    Task UpdateAsync(Guid id, ProductUpdateDto dto);
    Task RemoveAsync(Guid id);
}
