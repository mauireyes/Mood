using System;
namespace Doom.Common.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid UserId { get; set; }
    }
}
