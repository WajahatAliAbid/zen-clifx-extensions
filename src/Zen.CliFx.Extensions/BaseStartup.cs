using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Zen.CliFx.Extensions
{
    public abstract class BaseStartup
    {
        internal IServiceProvider Configure()
        {
            var services = new ServiceCollection();
            var configurationBuilder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json",optional: true);
            ConfigureAppConfiguration(configurationBuilder);
            var configuration = configurationBuilder.Build();
            services.AddSingleton<IConfigurationRoot>(configurationBuilder.Build());
            ConfigureServices(services, configuration);
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            ConfigureContainer(containerBuilder, configuration);
            return new AutofacServiceProvider(containerBuilder.Build());
        }
        public virtual void ConfigureAppConfiguration(IConfigurationBuilder configuration)
        {
        }
        public abstract void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration);

        public virtual void ConfigureContainer(ContainerBuilder container, IConfigurationRoot configuration)
        {
        }
    }
}