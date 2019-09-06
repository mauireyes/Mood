using System;
using System.Threading.Tasks;
using Doom.Common.Events;

namespace Doom.Api.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreated>
    {
        public UserCreatedHandler()
        {
        }

        public async Task HandleAsync(UserCreated @user)
        {
            // throw new NotImplementedException();
            await Task.CompletedTask;
            Console.WriteLine($"User created: {@user.Name}");
        }
    }
}
