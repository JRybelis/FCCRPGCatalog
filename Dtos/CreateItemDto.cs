using System.ComponentModel.DataAnnotations;

namespace FCCRPGCatalog.Dtos;

public record CreateItemDto
{
    [Required]
    public string Name { get; init; }
    [Required, Range(1, 5000)]
    public decimal Price { get; init; }
}