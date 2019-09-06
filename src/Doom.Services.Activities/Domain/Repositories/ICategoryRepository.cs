using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doom.Services.Activities.Domain.Models;

namespace Doom.Services.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {

        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category); 
    }
}
