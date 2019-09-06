using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Doom.Services.Identity.Services
{
    public interface IUserService
    {


        Task RegisterAsync(string email, string password, string name);
        //return secure token
        Task LoginAsync(string email, string password);
         //Task<JsonWebToken> LoginAsync(string email, string password);
    }
}
