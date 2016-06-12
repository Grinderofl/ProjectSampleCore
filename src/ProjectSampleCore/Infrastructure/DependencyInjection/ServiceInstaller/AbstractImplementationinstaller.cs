using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller.Strategies;
using ProjectSampleCore.Infrastructure.Install;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public abstract class AbstractImplementationinstaller : IServiceInstaller
    {
        protected abstract Func<TypeInfo, bool> Where { get; }
        protected abstract IServiceRegistrationStrategy Strategy { get; }
        protected abstract ServiceRegistrationScope RegistrationScope { get; }
        public virtual void Install(IServiceCollection services, IInstallerContext context)
        {
            var implementations = context.Assemblies.SelectMany(x => x.GetExportedTypes()).Where(t =>
            {
                var ti = t.GetTypeInfo();
                if (ti.IsAbstract)
                    return false;

                if (Where(ti))
                    return true;

                return false;
            });

            foreach(var implementation in implementations)
                Strategy.Register(services, implementation, RegistrationScope);
        }
    }
}