using System;
using System.Reflection;
using System.Threading.Tasks;
using Doom.Common.Commands;
using Doom.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using RawRabbit.Pipe.Middleware;

namespace Doom.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
          
            return bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
ctx => ctx.UseConsumeConfiguration(q => q.WithConsumerTag(GetQueueName<TCommand>())));
        }


        //public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
        //    ICommandHandler<TCommand> handler) where TCommand : ICommand
        //{
        //    return bus.SubscribeAsync<TCommand>(msg => (System.Threading.Tasks.Task<RawRabbit.Common.Acknowledgement>)handler.HandleAsync(msg),
        //                   ctx => ctx.UseConsumerConfiguration(cfg =>
        //                   cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));
        //}

        //private static string GetQueueName<T>()
        //=> $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
   IEventHandler<TEvent> handler) where TEvent : IEvent
   => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
       ctx => ctx.UseConsumeConfiguration(q => q.WithConsumerTag(GetQueueName<TEvent>())));



        //public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
        //   IEventHandler<TEvent> handler) where TEvent : IEvent
        //{
        //    return bus.SubscribeAsync<TEvent>(msg => (System.Threading.Tasks.Task<RawRabbit.Common.Acknowledgement>)handler.HandleAsync(msg),
        //                  ctx => ctx.UseConsumerConfiguration(cfg =>
        //                  cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));
        //}

        //private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";


        //public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var options = new RabbitMqOptions();
        //    var section = configuration.GetSection("rabbitmq"); //take from confiruration from aoppsetting.json
        //    section.Bind(options);
        //    var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
        //    {
        //        ClientConfiguration = options
        //    });
        //    services.AddSingleton<IBusClient>(_ => client); //singleton because we want rawrabbit to manage
        //}

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }



        //public Extensions()
        //{


        //}
    }
}
