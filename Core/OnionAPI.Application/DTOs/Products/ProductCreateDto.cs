namespace OnionAPI.Application.DTOs.Products;

public record ProductCreateDto
{
    public string Name { get; init; } = default!;
    public int Stock { get; init; }
    public long Price { get; init; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
