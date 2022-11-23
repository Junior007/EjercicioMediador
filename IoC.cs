using ConsoleApp.Handlers;
using ConsoleApp.Messages;
using ConsoleApp.Subscribers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    internal static class IoC
    {
        internal static void SetServices(IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(XXXX);
        }

        private static void XXXX(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddTransient<Worker>()
                    .AddSingleton<IMessageQueue, MessageQueue>()
                    .AddSingleton<IBusManager, BusManager>();


            services.Add(new ServiceDescriptor(typeof(IHandler), typeof(WriteFileMessageHandler<WriteFileMessage>), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IHandler), typeof(ProcessFileMessageHandler<WritedFileMessage>), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IHandler), typeof(DeleteFileMessageHandler<ProcessedFileMessage>), ServiceLifetime.Singleton));
        }
    }
}
