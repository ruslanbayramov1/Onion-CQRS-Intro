using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Features.Commands.CreateProduct;
using OnionAPI.Application.Features.Queries.GetAllProduct;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;
    private readonly IMediator mediator;
    public ProductsController(IProductService productService, IMediator mediator)
    {
        this.productService = productService;
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await productService.GetAllAsync();
        return Ok(entities);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllMediatRAsync()
    {
        var resp = await mediator.Send(new GetAllProductRequest());
        return Ok(resp.Products);
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

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PostMediatRAsync(CreateProductRequest req)
    {
        var resp = await mediator.Send(req);
        return StatusCode(StatusCodes.Status201Created, resp.ProductId);
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
