using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doom.Common.Mongo;
using Doom.Services.Activities.Domain.Models;
using Doom.Services.Activities.Domain.Repositories;
using MongoDB.Driver;

namespace Actio.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepository;

        public CustomMongoSeeder(IMongoDatabase database,
            ICategoryRepository categoryRepository)
            : base(database)
        {
            _categoryRepository = categoryRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "Good",
                "Bad",
                "Neutral"
            };
            await Task.WhenAll(categories.Select(x => _categoryRepository
                        .AddAsync(new Category(x))));
        }
    }
}