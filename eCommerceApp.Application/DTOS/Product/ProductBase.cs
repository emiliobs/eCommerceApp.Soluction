namespace eCommerceApp.Application.DTOS.Product;

public class ProductBase
{
    public string? Name { get; set; }

    public string? Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int Quantity { get; set; }

    private Guid CategoryId { get; set; }
}