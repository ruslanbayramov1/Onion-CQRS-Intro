namespace OnionAPI.Application.DTOs.Products;

public class ProductGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public long Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
