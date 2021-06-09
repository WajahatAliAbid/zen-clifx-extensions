using System;
using System.Threading;
using System.Threading.Tasks;
using CliFx;
using CliFx.Exceptions;
using CliFx.Infrastructure;

namespace Zen.CliFx.Extensions
{
    /// <summary>
    /// Base command for all autofac commands
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        public async ValueTask ExecuteAsync(IConsole console)
        {
            var cancellationToken = console.RegisterCancellationHandler();
            try
            {
                await ValidateAsync(cancellationToken);
            }
            catch (NotImplementedException) { }
            try
            {
                await ExecuteCommandAsync(console, cancellationToken);
            }
            catch (TaskCanceledException ex)
            {
                await console.Error.WriteLineAsync(ex.Message);
            }
        }

        /// <summary>
        /// Shows help for the command
        /// </summary>
        public ValueTask ShowCommandHelpAsync()
        {
            throw new CommandException("Please define a follow up command", showHelp: true);
        }
        /// <summary>
        /// Asynchoronously executes the command
        /// </summary>
        public abstract ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken);

        /// <summary>
        /// Used to validate the command
        /// </summary>
        public virtual ValueTask ValidateAsync(CancellationToken cancellationToken)
        {
            return default;
        }
    }
}