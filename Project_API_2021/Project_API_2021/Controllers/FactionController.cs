using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project_API_2021.Extra.DTO;
using Project_API_2021.Extra.Queries;
using Project_API_2021.Model;

namespace Project_API_2021.Controllers
{
    [Route("api/v1/factions")]
    [ApiController]
    public class FactionController : Controller
    {
        private readonly LeagueOfLegendsContext ctx;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public FactionController(LeagueOfLegendsContext context, IMediator mediator, IMapper mapper)
        {
            this.ctx = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFactions()
        {
            //CQRS
            /*  var query = new GetAllFactionQuery();
              var result = await _mediator.Send(query);
              return Ok(result);
              */

            //DTO
            /*List<FactionDTO> employees = _mapper.Map<List<Faction>, List<FactionDTO>>;
            return View(employees);
            */

            

            var faction = ctx.Factions;
            if (faction == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(faction);
            }
            
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var faction = ctx.Factions
                .Where(f => f.ID == id);

            if (faction != null)
            {
                return Ok(faction);
            }
            else
            {
                return NotFound("Could not find a faction with the id " + id);
            }
        }

        [HttpPost]
        public IActionResult AddFaction([FromBody] Faction factiondto)
        {

            // DTO POST
            //var faction = _mapper.Map<Faction>(factiondto);
           // return Ok(faction);


            ctx.Factions.Add(factiondto);
            ctx.SaveChanges();
            return Ok(factiondto);
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Faction updateFactions)
        {
            var faction = ctx.Factions.Find(id);
            if (faction == null)
            {
                return NotFound("Could not find a faction with the id " + id);
            }
            else
            {
                //faction.Champions = updateFactions.Champions;
                faction.FactionDesciption = updateFactions.FactionDesciption;
                faction.FactionName = updateFactions.FactionName;
                
                ctx.SaveChanges();
                return Ok(faction);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaction(int id)
        {
            Faction faction = ctx.Factions.Find(id);
            //DELEN VAN CHAMPON OOK?
            if (faction != null)
            {
                ctx.Factions.Remove(ctx.Factions.Find(id));
                ctx.SaveChanges();
                return Ok("Deleted faction with ID " + id);
            }
            return NotFound("No faction found with ID: " + id);
        }
    }
}
