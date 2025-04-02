namespace OnionAPI.Application.DTOs.Products;

public class ProductUpdateDto
{
    public string Name { get; set; } = default!;
    public int Stock { get; set; }
    public long Price { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
