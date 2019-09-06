using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Services.Activities.Services;
using Doom.Common.Commands;
using Doom.Common.Mongo;
using Doom.Common.RabbitMq;
using Doom.Services.Activities.Domain.Repositories;
using Doom.Services.Activities.Handlers;
using Doom.Services.Activities.Repositories;
using Doom.Services.Activities.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Doom.Services.Activities
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
            services.AddLogging();
            services.AddMongoDB(Configuration);

            //services.Configure<MongoOptions>(options =>
            //{
            //    options.ConnectionString
            //        = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            //    options.Database
            //        = Configuration.GetSection("MongoConnection:Database").Value;
            //});

            services.AddRabbitMq(Configuration);

            services.AddScoped<ICommandHandler<CreateMood>, CreateMoodHandler>();
            services.AddScoped<IMoodRepository, MoodRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddScoped<IMoodService, MoodService>();
           
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

            //how to invoke
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
