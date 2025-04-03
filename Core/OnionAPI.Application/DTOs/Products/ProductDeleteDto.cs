namespace OnionAPI.Application.DTOs.Products;

public record ProductDeleteDto
{
    public DateTime DeletedAt { get; init; } = DateTime.UtcNow;
    public bool IsDeleted { get; init; }
}
