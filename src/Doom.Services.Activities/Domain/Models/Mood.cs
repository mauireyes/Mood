using System;
using Doom.Common.Exceptions;

namespace Doom.Services.Activities.Domain.Models
{
    public class Mood
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public Guid UserId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        protected Mood()
        {
        }

        public Mood(Guid id, Category category, Guid userId,
        string name, string description, DateTime createdAt)
        {

            if(string.IsNullOrWhiteSpace(name))
            {
                throw new DoomException("empty activity name.",
                $"activity name can not empty");
            }


            Id = id;
            Category = category.Name;
            UserId = userId;
            Description = description;
            Name = name;
            CreatedAt = createdAt;
        }
    }
}
