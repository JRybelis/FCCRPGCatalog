using FCCRPGCatalog.Entities;
using System;
using System.Collections.Generic;

namespace FCCRPGCatalog.Repositiories;

public interface IItemsRepository
{
    IEnumerable<Item> GetItems();
    Item GetItemById(Guid id);
    void CreateItem(Item item);
}