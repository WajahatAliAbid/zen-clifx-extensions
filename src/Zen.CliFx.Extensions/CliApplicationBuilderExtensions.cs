using System.Threading.Tasks;
using CliFx;
using Microsoft.Extensions.DependencyInjection;

namespace Zen.CliFx.Extensions
{
    public static class CliApplicationBuilderExtensions
    {
        /// <summary>
        /// Uses the <see cref="TStartup"/> class for building Dependency container
        /// </summary>
        /// <param name="builder">instance of <see cref="CliApplicationBuilder"/></param>
        /// <typeparam name="TStartup">Class extending <see cref="BaseStartup"/></typeparam>
        /// <returns><see cref="CliApplicationBuilder"/></returns>
        public static CliApplicationBuilder UseStartup<TStartup>(this CliApplicationBuilder builder, string[] args = null) where TStartup : BaseStartup, new()
        {
            if(args is null)
                args = new string[0];
            TStartup startup = new TStartup();
            var services = startup.Configure(args);
            builder
                .UseTypeActivator(services.GetRequiredService);
            return builder;
        }

        /// <summary>
        /// Builds and runs the project
        /// </summary>
        /// <param name="builder">instance of <see cref="CliApplicationBuilder"/></param>
        /// <returns>Code for the app (0 for success, 1 for error)</returns>
        public static ValueTask<int> BuildAndRunAsync(this CliApplicationBuilder builder) => builder.Build().RunAsync();
    }
}