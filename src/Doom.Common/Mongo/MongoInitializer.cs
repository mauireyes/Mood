using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Doom.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        public MongoInitializer()
        {
        }

        private bool _initialized;
        private readonly IMongoDatabase _database;
        private readonly bool _seed;
        private readonly IDatabaseSeeder _seeder;

        public MongoInitializer(MongoDatabaseBase database, 
        IOptions<MongoOptions> options,
            IDatabaseSeeder seeder)
        {
            _seeder = seeder;
            _database = database;
            _seed = options.Value.Seed;
        }


        public async Task InitializeAsync()
        {
            //if Database is already initialized

            if(_initialized)
            {
                return;                
              }
            RegisterConventions();
            _initialized = true;

            //if we don't want to seed database, otherwise we'll create database seeder
            if(!_seed)
            {
                return;
            }

            await _seeder.SeedAsync();




        }

        private void RegisterConventions() => ConventionRegistry.Register("DoomConventions", new MongoConvention(), x => true);

        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
        {
            //if there are extra in class, and we dont want to serialize, we want to ignore
            new IgnoreExtraElementsConvention(true),
            new EnumRepresentationConvention(BsonType.String),
            new CamelCaseElementNameConvention()  //store enum as strings //store properties in database as camelcase
        };
        }

    }

}
