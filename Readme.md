# Zen CLiFx Extensions
[![Actions Status](https://github.com/WajahatAliAbid/zen-clifx-extensions/workflows/.NET%20Core%20Build/badge.svg?branch=main)](https://github.com/WajahatAliAbid/zen-clifx-extensions/actions) [![Actions Status](https://github.com/WajahatAliAbid/zen-clifx-extensions/workflows/.NET%20Core%20Publish/badge.svg)](https://github.com/WajahatAliAbid/zen-clifx-extensions/actions) [![Current Version](https://img.shields.io/badge/Version-1.0.0-brightgreen?logo=nuget&labelColor=30363D)](./CHANGELOG.md#100---2021-06-09)

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
using Zen.CliFx.Extensions;

public class Startup : BaseStartup
{
    public class Startup : BaseStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        public override void ConfigureContainer(ContainerBuilder container)
        {
        }
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
public override void ConfigureContainer(ContainerBuilder container)
{
    container.RegisterAllCommandsFromAssembly<MainCommand>();
}
```

### 5. Run the command
Run the command by using dotnet cli
```bash
> dotnet run
Hello World
```

