using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.Install;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies
{
    public class AllInterfacesRegistrationStrategy : ServiceRegistrationStrategy
    {
        public override void Register(IServiceCollection services, Type implementation, ServiceRegistrationScope registrationScope)
        {
            var interfaces = implementation.GetInterfaces();
            if (!interfaces.Any())
                throw new ArgumentException($"{implementation.Name} does not have any interfaces");

            var registrar = registrationScope.Registrar(services);
            foreach (var @interface in interfaces)
                registrar(@interface, implementation);
        }
    }
}