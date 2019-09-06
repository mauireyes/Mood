using System;
using System.Threading.Tasks;

namespace Doom.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}
