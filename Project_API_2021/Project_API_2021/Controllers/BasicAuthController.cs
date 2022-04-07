using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API_2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicAuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login([FromHeader] string authorization)
        {
            var credentials = authorization;
            if (!string.IsNullOrEmpty(credentials))
            {
                return Ok("Logged on");
            }
            Response.Headers.Add("WWW-Authenticate", "Basic");

            return Unauthorized();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return Unauthorized("Logged out");
        }
    }
}
