using System;
using System.Threading.Tasks;
using Doom.Common.Exceptions;
using Doom.Common.Commands;
using Doom.Common.Events;
using Doom.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;




namespace Doom.Services.Activities.Handlers
{
    public class CreateMoodHandler : ICommandHandler<CreateMood>
    {
        private readonly IBusClient _busClient;
        private readonly IMoodService _moodService;
        private readonly ILogger<CreateMoodHandler> _logger;



        public CreateMoodHandler(IBusClient busClient,
        IMoodService moodService, ILogger<CreateMoodHandler> logger)
        {
            _busClient = busClient;
            _moodService = moodService;
            _logger = logger;
        }


     

        public async Task HandleAsync(CreateMood command)
        {
            // throw new NotImplementedException();
            Console.WriteLine($"Creating mood: {command.Name}");

            try
            {
                await _moodService.AddAsync(command.Id, command.UserId,
                    command.Category, command.Name, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new MoodCreated(command.Id,
                    command.UserId, command.Category, command.Name, command.Description, command.CreatedAt));
                _logger.LogInformation($"Activity: '{command.Id}' was created for user: '{command.UserId}'.");

                return;
            }
            catch(DoomException ex)
            {
                _logger.LogError(ex, ex.Message);

                await _busClient.PublishAsync(new CreateMoodRejected (command.Id,
                    ex.Message, ex.Code));
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await _busClient.PublishAsync(new CreateMoodRejected(command.Id,
                    ex.Message, "error"));
            }

        }
    }
}
