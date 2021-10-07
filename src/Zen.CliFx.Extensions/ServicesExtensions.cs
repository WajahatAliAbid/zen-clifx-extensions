using Zen.Host;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Zen.CliFx.Extensions
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Registers all commands from assembly of <see cref="TCommand"/>
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <typeparam name="TCommand">Command extending BaseCommand</typeparam>
        /// <returns>Service collection</returns>
        public static IServiceCollection RegisterAllCommandsFromAssembly<TCommand>(this IServiceCollection services) where TCommand : BaseCommand
        {
            var assembly = typeof(TCommand).Assembly;
            var types = assembly.GetTypes()
                .Where(type => 
                {
                    if(!type.IsSubclassOf(typeof(BaseCommand)))
                        return false;
                    if(type.IsAbstract)
                        return false;
                    return true;

                });
            foreach (var type in types)
            {
                services.AddTransient(type);
            }
            return services;
        }
    }
}