using System;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies
{
    public abstract class ServiceRegistrationStrategy : IServiceRegistrationStrategy
    {
        public static IServiceRegistrationStrategy FirstInterface = new FirstInterfaceRegistrationStrategy();
        public static IServiceRegistrationStrategy AllInterfaces = new AllInterfacesRegistrationStrategy();
        public static IServiceRegistrationStrategy Self = new SelfRegistrationStrategy();
        public static IServiceRegistrationStrategy BasedOn(Type type) => new BasedOnRegistrationStrategy(type);

        public abstract void Register(IServiceCollection services, Type implementation, ServiceRegistrationScope registrationScope);
    }
}