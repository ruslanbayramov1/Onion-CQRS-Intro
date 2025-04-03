namespace OnionAPI.Application.DTOs.Products;

public record ProductUpdateDto
{
    public string Name { get; init; } = default!;
    public int Stock { get; init; }
    public long Price { get; init; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
