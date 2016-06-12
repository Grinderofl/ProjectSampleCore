using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.Install;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies
{
    public class FirstInterfaceRegistrationStrategy : ServiceRegistrationStrategy
    {
        public override void Register(IServiceCollection services, Type implementation, ServiceRegistrationScope registrationScope)
        {
            var firstInterface = implementation.GetInterfaces().FirstOrDefault();
            if (firstInterface == null)
                throw new ArgumentException($"{implementation.Name} does not have any interfaces");

            var registrar = registrationScope.Registrar(services);
            registrar(firstInterface, implementation);
        }
    }
}