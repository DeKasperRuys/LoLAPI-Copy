using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_API_2021.Model;

namespace Project_API_2021.Controllers
{

    [Route("api/v1/items")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly LeagueOfLegendsContext ctx;

        public ItemController(LeagueOfLegendsContext context)
        {
            this.ctx = context;
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Item newItem)
        {
            ctx.Items.Add(newItem);
            ctx.SaveChanges();

            return Created("This item has been added: ", newItem);
        }

        /*[Route("{id}")]
        [HttpGet]
        public IActionResult getItemById(int id)
        {
            var item = ctx.Items.Find(id);
            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound("Geen item gevonden met id " + id);
            }
        }*/

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            var item = ctx.Items.Find(id);
            if (item == null)
            {
                return NotFound("Item met dit ID bestaat niet.");
            }
            else
            {
                ctx.Items.Remove(item);
                ctx.SaveChanges();
                return Ok("Item met ID " + id + " is verwijderd");
            }
        }

        [HttpGet]
        //Alle items met paging en sorting
        public List<Item> GetAllItems(string name, int? page, string sort, int length = 2, string dir = "asc")
        {
            //Paging
            IQueryable<Item> query = ctx.Items;
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(i => i.ItemName == name);
            }
            if (page.HasValue)
            {
                query = query.Skip(page.Value * length);
                query = query.Take(length);
            }

            //sorting
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch(sort)
                {
                    case "name":
                        if (dir == "asc")
                            query = query.OrderBy(i => i.ItemName);
                        else if (dir == "desc")
                            query = query.OrderByDescending(i => i.ItemName);
                    break;
                        
                }
            }
            return query.ToList();

        }

        [HttpGet("{id}", Name = "GetitemById")]
        public IActionResult Get(int id)
        {
            var item = ctx.Items;

            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound("Could not find an item with the id " + id);
            }
        }
    }
}
