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

        [HttpPost] // Post/items
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(), Name = createItemDto.Name, Price = createItemDto.Price
                , CreationDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItemById), new {id = item.Id}, item.AsDto()); // returns the newly created item as GetItemById call in the response body
        } 
    }
}