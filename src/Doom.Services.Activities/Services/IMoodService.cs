using System;
using System.Threading.Tasks;

namespace Doom.Services.Activities.Services
{
    public interface IMoodService
    {
        Task AddAsync(Guid id, Guid userId, string category,
        string name, string description, DateTime createdAt);
    }
}
