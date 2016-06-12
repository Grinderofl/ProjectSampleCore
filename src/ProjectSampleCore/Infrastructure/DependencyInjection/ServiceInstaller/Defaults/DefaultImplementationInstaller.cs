using System;
using System.Reflection;
using ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Defaults
{
    public class DefaultImplementationInstaller : AbstractImplementationinstaller
    {
        protected override Func<TypeInfo, bool> Where => t => t.Namespace.EndsWith("Impl");
        protected override IServiceRegistrationStrategy Strategy => ServiceRegistrationStrategy.AllInterfaces;
        protected override ServiceRegistrationScope RegistrationScope => ServiceRegistrationScope.Scoped;
    }
}