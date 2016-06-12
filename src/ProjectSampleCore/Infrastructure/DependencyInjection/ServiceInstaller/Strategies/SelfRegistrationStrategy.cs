using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.Install;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies
{
    public class SelfRegistrationStrategy : ServiceRegistrationStrategy
    {
        public override void Register(IServiceCollection services, Type implementation, ServiceRegistrationScope registrationScope)
        {
            var registrar = registrationScope.Registrar(services);
            registrar(implementation, implementation);
        }
    }
}