using FCCRPGCatalog.Entities;
using System.Linq;

namespace FCCRPGCatalog.Repositiories;

public class InMemoryItemsRepository
{
    private readonly List<Item> items = new()
    {
        new Item{Id = Guid.NewGuid(), Name = "Potion", Price = 10, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Iron Longsword", Price = 35, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Bronze Dagger", Price = 15, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Mithril Pickaxe", Price = 230, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Adamant Helmet", Price = 280, CreationDate = DateTimeOffset.UtcNow},
        new Item{Id = Guid.NewGuid(), Name = "Steel Chainmail", Price = 150, CreationDate = DateTimeOffset.UtcNow},
    };

    public IEnumerable<Item> GetItems()
    {
        return items;
    }

    public Item GetItemById(Guid id)
    {
        return items.Where(item => item.Id == id).SingleOrDefault();
    }

}