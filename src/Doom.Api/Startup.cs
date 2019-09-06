using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doom.Api.Controllers;
using Doom.Api.Handlers;
using Doom.Common.Events;
using Doom.Common.Mongo;
using Doom.Common.RabbitMq;
using Doom.Services.Activities.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Doom.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRabbitMq(Configuration);
            services.AddMongoDB(Configuration);
            //api will be responsible for handling events, while command will handle by services
            //API will have subscribed to MoodCreatedHandler
            services.AddScoped<IEventHandler<MoodCreated>, MoodCreatedHandler>();
          //  services.AddScoped<IEventHandler<UserCreated>, UserCreatedHandler>();
          //  services.AddScoped<IMoodRepository, MoodRepository>();

           // services.AddScoped<IMoodRepository<MoodRepository>, MoodRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
