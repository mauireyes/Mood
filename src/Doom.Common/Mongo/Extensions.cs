﻿using System;
using Doom.Common.RabbitMq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RawRabbit;
using RawRabbit.Instantiation;

namespace Doom.Common.Mongo
{
    public static class Extensions
    {


        public static void AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoOptions>(configuration.GetSection("mongo"));
            services.AddSingleton<MongoClient>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                return new MongoClient(options.Value.ConnectionString);
            }
            );
            services.AddSingleton<IMongoDatabase>(c =>
            {
                var options = c.GetService<IOptions<MongoOptions>>();
                var client = c.GetService<MongoClient>();

                return client.GetDatabase(options.Value.ConnectionString);
            }
            );
            services.AddScoped<IDatabaseInitializer, MongoInitializer>();
            services.AddScoped<IDatabaseSeeder, MongoSeeder>();

        }

    }
}
