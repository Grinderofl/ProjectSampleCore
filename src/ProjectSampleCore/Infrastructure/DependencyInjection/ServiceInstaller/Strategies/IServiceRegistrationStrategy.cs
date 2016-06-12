using System;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.Install;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies
{
    public interface IServiceRegistrationStrategy
    {
        void Register(IServiceCollection services, Type implementation, ServiceRegistrationScope registrationScope);
    }
}