using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Doom.Common.Events;
using Doom.Common.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Doom.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<MoodCreated>()
                .Build()
                .Run();

            //service host will grab event handler
            // from services collection in startup.cs
            //and it will try to take it, subscribe to it and invoke event handler
        }



        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //WebHost.CreateDefaultBuilder(args)
                //.UseStartup<Startup>();
    }
}
