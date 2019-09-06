using System;
namespace Doom.Common.Events
{
    public class CreateMoodRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateMoodRejected()
        {
        }

        public CreateMoodRejected(Guid id,
            string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
