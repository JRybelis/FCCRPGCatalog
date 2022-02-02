using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
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
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        [HttpGet("{id}")] // GET/items/{id}
        public ActionResult<Item> GetItemById(Guid id)
        {
            var item = repository.GetItemById(id);

            if(item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}