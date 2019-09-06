using System;
using System.Threading.Tasks;
using Doom.Common.Exceptions;
using Doom.Services.Identity.Domain.Models;
using Doom.Services.Identity.Domain.Repositories;
using Doom.Services.Identity.Domain.Services;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Doom.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
   //     private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository repository,
            IEncrypter encrypter)
         ///   IJwtHandler jwtHandler)
        {
            _userRepository = repository;
            _encrypter = encrypter;
          //  _jwtHandler = jwtHandler;
        }

     

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new DoomException("email_in_use",
                    $"Email: '{email}' is already in use.");
            }
            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }

        //public async Task<JsonWebToken> LoginAsync(string email, string password)
        //{
        //    var user = await _repository.GetAsync(email);
        //    if (user == null)
        //    {
        //        throw new DoomException("invalid_credentials",
        //            $"Invalid credentials.");
        //    }
        //    if (!user.ValidatePassword(password, _encrypter))
        //    {
        //        throw new DoomException("invalid_credentials",
        //            $"Invalid credentials.");
        //    }

        //    return _jwtHandler.Create(user.Id);
        //}

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new DoomException("invalid_credentials",
                    $"Invalid credentials.");
            }
            if (!user.ValidatePassword(password, _encrypter))
            {
                throw new DoomException("invalid_credentials",
                    $"Invalid credentials.");
            }

            //return _jwtHandler.Create(user.Id);
        }
    }
}
