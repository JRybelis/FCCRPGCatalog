namespace FCCRPGCatalog.Entities;

//Record type: used for immutable objects, support value-based equality, and with-expressions in C#9
public record Item
{
    public Guid Id { get; init; }//init-only, cannot set afterwards, property
    public string Name { get; init; }
    public decimal Price { get; init; }
    public DateTimeOffset CreationDate { get; init; }
    
}

