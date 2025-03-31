namespace OnionAPI.Application.DTOs.Products;

public class ProductCreateDto
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public long Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
