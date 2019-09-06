using System;
using System.Threading.Tasks;
using Doom.Services.Activities.Domain.Models;

namespace Doom.Services.Activities.Domain.Repositories
{
    public interface IMoodRepository
    {
        Task<Mood> GetAsync(Guid id);
        Task AddAsync(Mood mood);
        //we can extend repository with crud
    }
}
