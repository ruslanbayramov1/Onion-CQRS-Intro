using Microsoft.AspNetCore.Mvc;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;
    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await productService.GetAllAsync();
        return Ok(entities);
    }

    [HttpGet]
    [Route("{productId:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid productId)
    {
        var entity = await productService.GetByIdAsync(productId);
        return Ok(entity);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PostAsync(ProductCreateDto dto)
    { 
        var id = await productService.AddAsync(dto);
        return StatusCode(StatusCodes.Status201Created, id);
    }

    [HttpPut]
    [Route("{productId:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid productId, ProductUpdateDto dto)
    {
        await productService.UpdateAsync(productId, dto);
        return Created();
    }

    [HttpDelete]
    [Route("{productId:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid productId)
    {
        await productService.RemoveAsync(productId);
        return NoContent();
    }
}
