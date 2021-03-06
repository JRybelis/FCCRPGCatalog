using FCCRPGCatalog.Entities;
using FCCRPGCatalog.Repositiories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FCCRPGCatalog.Repositories;

public class MongoDBItemsRepository : IItemsRepository
{
    private const string databaseName = "FCCRPGCatalog";
    private const string collectionName = "items";
    private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
    private readonly IMongoCollection<Item> itemsCollection;
    
    public MongoDBItemsRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(databaseName);
        itemsCollection = database.GetCollection<Item>(collectionName);
    }
    
    public IEnumerable<Item> GetItems()
    {
        return itemsCollection.Find(new BsonDocument()).ToList();
    }

    public Item GetItemById(Guid id)
    {
        var filter = filterBuilder.Eq(item => item.Id, id);
        return itemsCollection.Find(filter).SingleOrDefault();
    }

    public void CreateItem(Item item)
    {
        itemsCollection.InsertOne(item);
    }

    public void UpdateItem(Item item)
    {
        var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
        itemsCollection.ReplaceOne(filter, item);
    }

    public void DeleteItem(Guid id)
    {
        var filter = filterBuilder.Eq(itemToDelete => itemToDelete.Id, id);
        itemsCollection.DeleteOne(filter);
    }
}