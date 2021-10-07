using System.Threading;
using System.Threading.Tasks;
using CliFx.Infrastructure;

namespace Zen.CliFx.Extensions
{
    public abstract class BaseHelpCommand : BaseCommand
    {
        public override sealed ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
        {
            return ShowCommandHelpAsync();
        }
    }
}