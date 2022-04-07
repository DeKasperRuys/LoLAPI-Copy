using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_API_2021.Model;

namespace Project_API_2021.Controllers
{

    [Route("api/v1/backgrounds")]
    [ApiController]
    public class BackgroundController : Controller
    {
        private readonly LeagueOfLegendsContext ctx;

        public BackgroundController(LeagueOfLegendsContext context)
        {
            this.ctx = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var background = ctx.Backgrounds;
            if (background == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(background);
            }

        }

        [HttpGet("{id}", Name = "GetBackgroundById")]
        public IActionResult Get(int id)
        {
            var background = ctx.Backgrounds;

            if (background != null)
            {
                return Ok(background);
            }
            else
            {
                return NotFound("Could not find a background with the id " + id);
            }
        }


    }
}
