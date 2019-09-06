using System;
namespace Doom.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {

        Guid UserId { get; set; }
    }
}
