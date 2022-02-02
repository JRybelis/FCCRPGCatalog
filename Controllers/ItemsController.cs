using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using FCCRPGCatalog;
using FCCRPGCatalog.Dtos;
using FCCRPGCatalog.Entities;
using FCCRPGCatalog.Repositiories;


namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]// makes the endpoint the name of this controller. Alternatively, we could specify the route as "items"
    public class ItemsController : ControllerBase // inherit from ControllerBase to make this class into a controller class, specifically
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository) // dependency injection
        {
            this.repository = repository;
        }
        
        [HttpGet] // GET/items will call this method
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto()); // using static extension method to map entity to dto
            return items;
        }

        [HttpGet("{id}")] // GET/items/{id}
        public ActionResult<ItemDto> GetItemById(Guid id)
        {
            var item = repository.GetItemById(id);

            if(item is null)
            {
                return NotFound();
            }
            return Ok(item.AsDto());
        }

        [HttpPost] // POST/items
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(), Name = createItemDto.Name, Price = createItemDto.Price
                , CreationDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItemById), new {id = item.Id}, item.AsDto()); // takes the newly created item, maps it as itemDto and returns it as GetItemById call in the response body
        }

        [HttpPut("{id}")] //PUT/items/{id}
        public ActionResult UpdateItem (Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = repository.GetItemById(id);
            
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with // with expression helps create a copy of the existingItem with the props declared below and assign it to updatedItem
            {
                Name = updateItemDto.Name, Price = updateItemDto.Price
            };
            
            repository.UpdateItem(updatedItem);
            return NoContent(); // the convention for HttpPut is to return nothing
        }

        [HttpDelete("{id}")] // DELETE/items/{id}
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItemById(id);
            
            if (existingItem is null)
            {
                return NotFound();
            }
            
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}