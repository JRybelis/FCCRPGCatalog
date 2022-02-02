namespace FCCRPGCatalog.Dtos;

public record CreateItemDto
{
    public string Name { get; init; }
    public decimal Price { get; init; }
}