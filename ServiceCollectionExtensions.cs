using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConsoleApp
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => 
                    a.DefinedTypes.Where(                
                        x => x.GetInterfaces().Contains(typeof(T)) && !x.IsInterface && !x.IsAbstract
                ));

            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }
    }
}
