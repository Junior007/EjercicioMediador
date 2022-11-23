using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConsoleApp;

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

IoC.SetServices(hostBuilder);



IHost host = hostBuilder.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

Worker worker = provider.GetRequiredService<Worker>();

worker.Run();

await host.RunAsync();

