namespace OnionAPI.Application.DTOs.Products;

public record ProductGetDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Stock { get; init; }
    public long Price { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
