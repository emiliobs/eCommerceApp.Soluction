using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Domain.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int Quantity { get; set; }

    public Category? Category { get; set; }

    private Guid CategoryId { get; set; }
}