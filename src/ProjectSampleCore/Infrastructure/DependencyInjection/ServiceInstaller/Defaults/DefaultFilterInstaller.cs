using System;
using System.Reflection;
using ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Defaults
{
    public class DefaultFilterInstaller : AbstractImplementationinstaller
    {
        protected override Func<TypeInfo, bool> Where => t => t.Namespace.EndsWith("Filters");
        protected override IServiceRegistrationStrategy Strategy => new SelfRegistrationStrategy();
        protected override ServiceRegistrationScope RegistrationScope => ServiceRegistrationScope.Scoped;
    }
}