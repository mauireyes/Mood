using System;
namespace Doom.Common.Events
{
    public interface IRejectedEvent : IEvent
    {
        //some operation was rejected
        string Reason { get; } //message that contains reason
        string Code { get; } //error code for reference in API e.g. invalid email code 4
        //could be enum - using string for simplicity
    }
}
