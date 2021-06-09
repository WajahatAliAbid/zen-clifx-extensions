using Autofac;

namespace Zen.CliFx.Extensions
{
    public static class AutofacExtensions
    {
        /// <summary>
        /// Registers all commands from assembly of <see cref="TCommand"/>
        /// </summary>
        /// <param name="container">Autofac container builder</param>
        /// <typeparam name="TCommand">Command extending BaseCommand</typeparam>
        /// <returns>Autofac container builder</returns>
        public static ContainerBuilder RegisterAllCommandsFromAssembly<TCommand>(this ContainerBuilder container) where TCommand : BaseCommand
        {
            container.RegisterAssemblyTypes(typeof(TCommand).Assembly)
                .Where(a => a.IsSubclassOf(typeof(TCommand)));
            return container;
        }
    }
}