using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_API_2021.Model;

namespace Project_API_2021.Controllers
{
    [Route("api/v1/champions")]
    [ApiController]
    public class ChampionController : Controller
    {
        private readonly LeagueOfLegendsContext ctx;

        public ChampionController(LeagueOfLegendsContext context)
        {
            this.ctx = context;
        }

        [HttpPost]
        public IActionResult AddChampion([FromBody] Champion champion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.Champions.Add(champion);
            ctx.SaveChanges();
            return Ok(champion);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChampion(int id)
        {
            Champion champion = ctx.Champions.Find(id);
            if (champion != null)
            {
                ctx.Champions.Remove(champion);
                ctx.SaveChanges();
                return Ok("Deleted champion with ID " + id);
            }
            return NotFound("No champion found with ID: " + id);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Champion updateChampions)
        {
            var champions = ctx.Champions.Find(updateChampions.ID);
            if (champions == null)
            {
                return NotFound("Could not find a champion with the id " + updateChampions.ID);
            }
            else
            {
                //champions.Faction.ID = updateChampions.Faction.ID;
                champions.FactionId = updateChampions.FactionId;
                champions.ChampionName = updateChampions.ChampionName;
                champions.ChampionRole = updateChampions.ChampionRole;
                champions.ReleaseDate = updateChampions.ReleaseDate;
                //champions.ChampionStory = updateChampions.ChampionStory;
                ctx.SaveChanges();
                return Ok(champions);
            }
        }


        [HttpGet]
        public List<Champion> GetAllChampions(string name, string role, int? page, string sort, int length = 100, string dir = "asc")
        {



            IQueryable<Champion> query = ctx.Champions;
            ///////// Filtering /////////
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(d => d.ChampionName == name);
            if (!string.IsNullOrWhiteSpace(role))
                query = query.Where(d => d.ChampionRole == role);
            /////// Filtering //////////

            ////////SORTING//////////////
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "name":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.ChampionName);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.ChampionName);

                        break;

                    case "role":
                        if (dir == "asc")
                            query = query.OrderBy(d => d.ChampionRole);
                        else if (dir == "desc")
                            query = query.OrderByDescending(d => d.ChampionRole);
                        break;


                }


            }
            ////////SORTING//////////////
            /////////PAGING///////////////

            if (page.HasValue)
                query = query.Skip(page.Value * length);
            query = query.Take(length);

            /////////PAGING///////////////




            return query.ToList();


        }
        /*
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<Champion> query = ctx.Champions;

            var champ = ctx.Champions;//.Include(c => c.ChampionFaction);
            if (champ == null)
            {
                return NotFound();
            }
            else
            {
                
                return Ok(champ);
            }

        }
        */


        [HttpGet("{id}", Name = nameof(GetChampions))]
        public IActionResult GetChampions(int id)
        {
            var champions = ctx.Champions.Include(c => c.Faction).SingleOrDefault(c => c.ID == id);
            
            if (champions != null)
            {
                return Ok(champions);
            }
            else
            {
                return NotFound("Could not find a champion with the id " + id);
            }
        }

        [Route("faction")]
        [HttpGet]
        public IActionResult GetChampionAndFaction(int idin)
        {
            var champwfaction = ctx.Champions
                                .Include(d => d.Faction).Where(d => d.Faction.ID == idin);





            if (champwfaction == null)
                return NotFound();

            return Ok(champwfaction);

        }

        /*[HttpGet]
        public IActionResult GetName(string name)
        {
            IQueryable<Champion> champion = ctx.Champions;
            if (!string.IsNullOrWhiteSpace(name))
                champion = champion.Where(c => c.ChampionName == name);
            return Ok(champion);

            
        }*/

       

        

       



        
    }
}
