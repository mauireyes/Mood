using System;
using System.Threading.Tasks;

namespace Doom.Common.Mongo
{
    public interface IDatabaseSeeder
    {

        Task SeedAsync();
    }
}
