using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.Install;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies
{
    public class BasedOnRegistrationStrategy : ServiceRegistrationStrategy
    {
        private readonly Type _baedOn;

        public BasedOnRegistrationStrategy(Type baedOn)
        {
            _baedOn = baedOn;
        }

        public override void Register(IServiceCollection services, Type implementation, ServiceRegistrationScope registrationScope)
        {
            var registrar = registrationScope.Registrar(services);
            registrar(_baedOn, implementation);
        }
    }
}