using System.Threading;
using System.Threading.Tasks;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Zen.CliFx.Extensions.Tests
{
    public class DIExtensions
    {
        [Fact]
        public void CanAddCommandsFromAssembly()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterAllCommandsFromAssembly<CommandA>();
            var provider = serviceCollection.BuildServiceProvider();

            var commandA = provider.GetService<CommandA>();
            var commandB = provider.GetService<CommandB>();
            var commandC = provider.GetService<CommandC>();
            Assert.NotNull(commandA);
            Assert.NotNull(commandB);
            Assert.NotNull(commandC);
        }

        [Fact]
        public void CanAddHelpCommandsFromAssembly()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterAllCommandsFromAssembly<CommandA>();
            var provider = serviceCollection.BuildServiceProvider();

            var group = provider.GetService<GroupCommand>();
            Assert.NotNull(group);
        }

        [Fact]
        public void CannotAddCommandsWhichAreAbstractClasses()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.RegisterAllCommandsFromAssembly<CommandA>();
            var provider = serviceCollection.BuildServiceProvider();

            var commandA = provider.GetService<AbstractCommand>();
            Assert.Null(commandA);
        }
    }

    [Command("commandA")]
    public class CommandA : BaseCommand
    {
        public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    [Command("commandB")]
    public class CommandB : BaseCommand
    {
        public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    [Command("commandC")]
    public class CommandC : BaseHelpCommand
    {
    }

    public abstract class AbstractCommand : BaseCommand
    {

    }

    [Command("group")]
    public class GroupCommand : BaseHelpCommand
    {

    }
}