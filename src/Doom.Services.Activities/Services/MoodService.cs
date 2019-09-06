using System;
using System.Threading.Tasks;
using Doom.Common.Exceptions;
using Doom.Services.Activities.Domain.Models;
using Doom.Services.Activities.Domain.Repositories;

namespace Doom.Services.Activities.Services
{
    public class MoodService : IMoodService
    {

        public IMoodRepository _moodRepository { get; }
        public ICategoryRepository _categoryRepository { get; }

        public MoodService(IMoodRepository moodRepository,
        ICategoryRepository categoryRepository)
        {
            this._moodRepository = moodRepository;
            this._categoryRepository = categoryRepository;
        }

       
        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var moodCategory = await _categoryRepository.GetAsync(name);
            if(moodCategory == null)
            {
                throw new DoomException("Category not found", $"Category: '{category} was not found.'");
            }
            var mood = new Mood(id, moodCategory, userId, name, description, createdAt);

            await _moodRepository.AddAsync(mood);
       }
    }
}
