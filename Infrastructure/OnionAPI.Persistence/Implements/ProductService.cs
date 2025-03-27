using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Interfaces;
using OnionAPI.Domain.Entities;
using OnionAPI.Domain.Exceptions.Common;
using OnionAPI.Persistence.Contexts;

namespace OnionAPI.Persistence.Implements;

public class ProductService : IProductService
{
    private readonly OnionApiDbContext context;
    private readonly IMapper mapper;
    public ProductService(OnionApiDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public async Task<Guid> AddAsync(ProductCreateDto dto)
    {
        var entity = mapper.Map<Product>(dto);
        await context.Products.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<ProductGetDto>> GetAllAsync()
        => await context.Products
        .Select(x => new ProductGetDto
        {
            Id = x.Id,
            Name = x.Name,
            CreatedAt = x.CreatedAt,
            Price = x.Price,
            Stock = x.Stock,
        }).ToListAsync();

    public async Task<ProductGetDto> GetByIdAsync(Guid id)
    {
        var entity = await getById(id);
        var data = mapper.Map<ProductGetDto>(entity);
        return data;
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await getById(id);
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, ProductUpdateDto dto)
    {
        var entity = await getById(id);
        mapper.Map(dto, entity);
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    private async Task<Product> getById(Guid id)
    { 
        var data = await context.Products.Where(x => x.Id == id)
        .Select(x => new Product
        {
            Id = x.Id,
            Name = x.Name,
            CreatedAt = x.CreatedAt,
            Price = x.Price,
            Stock = x.Stock,
            IsDeleted = x.IsDeleted,
            RemovedAt = x.RemovedAt,
            UpdatedAt = x.UpdatedAt
        }).FirstOrDefaultAsync();

        if (data == null) throw new NotFoundException<Product>();
        return data;
    }
}
