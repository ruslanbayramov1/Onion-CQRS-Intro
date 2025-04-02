namespace OnionAPI.Application.DTOs.Products;

public class ProductDeleteDto
{
    public DateTime DeletedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }
}
