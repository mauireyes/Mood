using System;
using System.Threading.Tasks;
using Doom.Common.Events;

namespace Doom.Api.Handlers
{
    public class MoodCreatedHandler : IEventHandler<MoodCreated>
    {
        public MoodCreatedHandler()
        {
        }

        public async Task HandleAsync(MoodCreated @mood)
        {
            // throw new NotImplementedException();
            await Task.CompletedTask;
            Console.WriteLine($"Mood created: {@mood.Name}");
        }
    }
}
