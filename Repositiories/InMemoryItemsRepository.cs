using FCCRPGCatalog.Entities;

namespace FCCRPGCatalog.Repositiories;

public class InMemoryItemsRepository
{
    private readonly List<Item> items = new()
    {
        new Item{Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Iron Longsword", Price = 9, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Bronze Dagger", Price = 9, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Mithril Pickaxe", Price = 9, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Adamant Helmet", Price = 9, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Steel Chainmail", Price = 9, CreationDate = DateTimeOffset.UtcNow},
    };

}