using System;
using System.Threading.Tasks;
using Doom.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Doom.Api.Controllers
{
    //defining basic endpoints to api

    //Base endpoint to be of Type DoomControllerco
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IBusClient _busClient;

        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        //whenever we do a post to activities, it will invoke this operation here
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
        
            await _busClient.PublishAsync(command); //how we can send message to bus, by invoking this method

            return Accepted(); //return without endpoint- relative turl to endpoint hwere activity will be fetch from
        }

    }
}
