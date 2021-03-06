using FCCRPGCatalog.Dtos;
using FCCRPGCatalog.Entities;

namespace FCCRPGCatalog;

public static class Extensions
{
    public static ItemDto AsDto(this Item item)
    {
        return new ItemDto()
        {
            Id = item.Id, Name = item.Name, Price = item.Price, CreationDate = item.CreationDate
        };
    } 
}