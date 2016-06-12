using System;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public class ServiceRegistrationScope
    {
        public static ServiceRegistrationScope Singleton =
            new ServiceRegistrationScope(
                services =>
                    ((serviceType, implementationType) => services.AddSingleton(serviceType, implementationType)));

        public static ServiceRegistrationScope Scoped =
            new ServiceRegistrationScope(
                services =>
                    ((serviceType, implementationType) => services.AddScoped(serviceType, implementationType)));
        
        private ServiceRegistrationScope(Func<IServiceCollection, Action<Type, Type>> registrar)
        {
            Registrar = registrar;
        }
        public virtual Func<IServiceCollection, Action<Type, Type>> Registrar { get; }
    }
}