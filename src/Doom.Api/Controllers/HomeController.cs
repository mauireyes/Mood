using System;
using Microsoft.AspNetCore.Mvc;

namespace Doom.Api.Controllers


{

    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from DOOM API!");


        public HomeController()
        {
        }
    }
}
