# Zen CLiFx Extensions
[![Actions Status](https://github.com/WajahatAliAbid/zen-clifx-extensions/workflows/.NET%20Core%20Build/badge.svg?branch=main)](https://github.com/WajahatAliAbid/zen-clifx-extensions/actions) [![Actions Status](https://github.com/WajahatAliAbid/zen-clifx-extensions/workflows/.NET%20Core%20Publish/badge.svg)](https://github.com/WajahatAliAbid/zen-clifx-extensions/actions) [![Current Version](https://img.shields.io/badge/Version-1.2.0-brightgreen?logo=nuget&labelColor=30363D)](./CHANGELOG.md#120---2021-06-12)

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
    public override void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
    {
    }

    public override void ConfigureContainer(ContainerBuilder container, IConfigurationRoot configuration)
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
public override void ConfigureContainer(ContainerBuilder container, IConfigurationRoot configuration)
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

## Additional options
You can load configurations from a json file by just adding a file appsettings.json file and adding it to csproj file like following
```xml
<ItemGroup>
    <None Update="appsettings.json">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
</ItemGroup>
```

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
