using System;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InstallServices(this IServiceCollection services, Action<ServiceInstallerOptions> options)
        {
            var installerOptions = new ServiceInstallerOptions();
            options(installerOptions);
            CreateFactoryAndExecute(services, installerOptions);

            return services;
        }

        private static void CreateFactoryAndExecute(IServiceCollection services, ServiceInstallerOptions installerOptions)
        {
            var factory = new ServiceInstallerExecutorFactory(installerOptions);
            var executor = factory.Create();
            executor.Execute(services);
        }
    }
}