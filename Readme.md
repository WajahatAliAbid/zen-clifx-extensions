# Zen CLiFx Extensions
[![Actions Status](https://github.com/WajahatAliAbid/zen-clifx-extensions/workflows/.NET%20Core%20Build/badge.svg?branch=main)](https://github.com/WajahatAliAbid/zen-clifx-extensions/actions) [![Actions Status](https://github.com/WajahatAliAbid/zen-clifx-extensions/workflows/.NET%20Core%20Publish/badge.svg)](https://github.com/WajahatAliAbid/zen-clifx-extensions/actions) [![Current Version](https://img.shields.io/badge/Version-1.6.1-brightgreen?logo=nuget&labelColor=30363D)](./CHANGELOG.md#161---2021-10-07)

# Overview

## Installing
You can add the package to your project using dotnet core CLI
```bash
dotnet add package Zen.CliFx.Extensions
```
or by package manager console in Visual Studio
```bash
Install-Package Zen.CliFx.Extensions
```

## Usage
Use the following steps to configure Zen CliFx Extensions. Please refer to [Changelog](./CHANGELOG.md) for changes between versions.

### 1. Create Startup Class
```csharp
using Zen.Host;

public class Startup : BaseStartup
{
    public override void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
    {
    }
}
```

### 2. Configure Program file
```csharp
using CliFx;
using Zen.CliFx.Extensions;

class Program
{
    public static async Task<int> Main() => 
        await new CliApplicationBuilder()
            .SetTitle("My CLI")
            .SetDescription("Doing cool stuff")
            .AddCommandsFromThisAssembly()
            .UseStartup<Startup>()
            .BuildAndRunAsync();
}
```

### 3. Add a command
```csharp
[Command]
public class MainCommand : BaseCommand
{
    public override async ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        await console.Output.WriteLineAsync("Hello World");
    }
}
```

### 4. Register commands with DI
```csharp
public override void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
{
    services.RegisterAllCommandsFromAssembly<MainCommand>();
}
```

### 5. Run the command
Run the command by using dotnet cli
```bash
> dotnet run
Hello World
```

## Additional options
You can display command help on running a command by using following code snippet
```csharp
[Command]
class PlaceholderCommand : BaseCommand
{
    public ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
```
Or you can create a command which only displays help
```csharp
[Command]
class HelpCommand : BaseHelpCommand
{

}
```