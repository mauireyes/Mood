using System;
namespace Doom.Common.Events
{
    public class MoodCreated : IAuthenticatedEvent
    {


        public Guid Id { get; }

        public Guid UserId { get; }

        public string Category { get; }

        public string Name { get;  }

        public string Description { get; }
        public DateTime CreatedAt { get; }
        Guid IAuthenticatedEvent.UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected MoodCreated()
        {

        }

        public MoodCreated(Guid id, Guid userId, string category, string name,
        string description, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}
