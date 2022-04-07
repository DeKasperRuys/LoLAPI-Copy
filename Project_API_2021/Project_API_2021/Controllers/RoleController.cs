using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_API_2021.Model;

namespace Project_API_2021.Controllers
{

    [Route("api/v1/Roles")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly LeagueOfLegendsContext ctx;

        public RoleController(LeagueOfLegendsContext context)
        {
            this.ctx = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var role = ctx.Roles;
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(role);
            }

        }

        [HttpGet("{id}", Name = "GetRoleById")]
        public IActionResult Get(int id)
        {
            var role = ctx.Roles;

            if (role != null)
            {
                return Ok(role);
            }
            else
            {
                return NotFound("Could not find a role with the id " + id);
            }
        }
    }
}
