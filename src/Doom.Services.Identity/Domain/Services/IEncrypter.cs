using System;
namespace Doom.Services.Identity.Domain.Services
{
    public interface IEncrypter
    {
        //
        //our password will have secured string called, salt, then pass hash and salt then create hash
        string GetSalt();
        string GetHash(string value, string salt);
    }
}
