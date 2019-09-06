using System;
using System.Threading.Tasks;
using Doom.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Doom.Api.Controllers
{
   
    //Base endpoint to be of Type DoomControllerco
    [Route("[controller]")]
    public class MoodController : Controller
    {
    //   private readonly IMoodRepository _mood;

        private readonly IBusClient _busClient;

        public MoodController(IBusClient busClient)
        {
            _busClient = busClient;
        }

         //whenever we do a post to mood, it will invoke this operation here
        [HttpPost("")]
         public async Task<IActionResult> Post([FromBody]CreateMood command)
        {

            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            await _busClient.PublishAsync(command);

            return Accepted($"mood/{command.Id}"); //relative url to endpoint hwere activity will be fetch from
        }


        ////whenever we do a post to mood, it will invoke this operation here
        //[HttpPost("")]
        //public async Task<IActionResult> Post([FromBody]CreateMood command)
        //{
        //   // _mood.AddAsync()
        //    command.Id = Guid.NewGuid();
        //    command.CreatedAt = DateTime.UtcNow;
        //    await _busClient.PublishAsync(command);

        //    return Accepted($"mood/{command.Id}"); //relative url to endpoint hwere activity will be fetch from
        //}
    }
}
