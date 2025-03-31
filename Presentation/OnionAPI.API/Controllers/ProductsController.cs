using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Features.Commands.CreateProduct;
using OnionAPI.Application.Features.Queries.GetAllProduct;
using OnionAPI.Application.Features.Queries.GetByIdProduct;
using OnionAPI.Application.Interfaces;

namespace OnionAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductPostgreService productService;
    private readonly IMediator mediator;
    public ProductsController(IProductPostgreService productService, IMediator mediator)
    {
        this.productService = productService;
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var resp = await mediator.Send(new GetAllProductRequest());
        return Ok(resp);
    }

    [HttpGet]
    [Route("{productId:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid productId)
    {
        var response = await mediator.Send(new GetByIdProductRequest() { ProductId = productId });
        return Ok(response);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PostAsync(CreateProductRequest req)
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
        await productService.DeleteAsync(productId);
        return NoContent();
    }
}
