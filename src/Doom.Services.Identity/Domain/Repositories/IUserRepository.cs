using System;
using System.Threading.Tasks;
using Doom.Services.Identity.Domain.Models;

namespace Doom.Services.Identity.Domain.Repositories
{
    public interface IUserRepository
    {


        Task<User> GetAsync(Guid id);
         Task<User> GetAsync(string email);
         Task AddAsync(User user);

      
    }
}
