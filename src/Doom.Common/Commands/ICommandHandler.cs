using System;
using System.Threading.Tasks;

namespace Doom.Common.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
