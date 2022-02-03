using FCCRPGCatalog.Entities;
using FCCRPGCatalog.Repositiories;

namespace FCCRPGCatalog.Repositories;

public class InMemoryItemsRepository : IItemsRepository
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

    public void CreateItem(Item item)
    {
        items.Add(item);
    }

    public void UpdateItem(Item item)
    {
        var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
        items[index] = item;
    }

    public void DeleteItem(Guid id)
    {
        var index = items.FindIndex(existingItem => existingItem.Id == id);
        items.RemoveAt(index);
    }
}