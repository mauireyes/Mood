using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doom.Services.Activities.Domain.Models;
using Doom.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Doom.Services.Activities.Repositories
{
    public class MoodRepository : IMoodRepository
    {
        private readonly IMongoDatabase _database;

        public MoodRepository(IMongoDatabase database)

        {

            _database = database;
        }

        public async Task AddAsync(Mood mood)
        {
            await Collection.InsertOneAsync(mood);
        }

      
        public async Task<Mood> GetAsync(Guid id)
        {
            return await Collection
                       .AsQueryable()
                       .FirstOrDefaultAsync(x => x.Id == id);
        }


        //to fetch the coll of categories 
        //return database for category
        private IMongoCollection<Mood> Collection
        => _database.GetCollection<Mood>("Moods");


    }
}
