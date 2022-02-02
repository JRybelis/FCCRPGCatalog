namespace FCCRPGCatalog.Dtos;

public class ItemDto
{
    public Guid Id { get; init; }//init-only, cannot set afterwards, property
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTimeOffset CreationDate { get; init; }

}