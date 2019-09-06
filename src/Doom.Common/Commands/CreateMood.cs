using System;
namespace Doom.Common.Commands
{
    public class CreateMood : IAuthenticatedCommand
    {
        public CreateMood()
        {
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}