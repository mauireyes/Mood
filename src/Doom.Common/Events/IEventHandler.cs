using System;
using System.Threading.Tasks;

namespace Doom.Common.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T command);
        //services can subscribe to particular events,
        // consume them, and perform some business logic
    }
}
