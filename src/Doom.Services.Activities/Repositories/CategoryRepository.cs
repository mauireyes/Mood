using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doom.Services.Activities.Domain.Models;
using Doom.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Doom.Services.Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository

    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)

        {

            _database = database;
        }

        public async Task AddAsync(Category category)
        {
            await Collection.InsertOneAsync(category);
        }

        public async Task<IEnumerable<Category>> BrowseAsync() 
        => await Collection
            .AsQueryable()
            .ToListAsync();

        public async Task<Category> GetAsync(string name)
        {
            return await Collection
                       .AsQueryable()
                       .FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());
        }


        //to fetch the coll of categories 
        //return database for category
        private IMongoCollection<Category> Collection
        => _database.GetCollection<Category>("Categories");

    
    }
}
