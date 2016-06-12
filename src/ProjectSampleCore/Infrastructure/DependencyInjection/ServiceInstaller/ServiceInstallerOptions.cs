using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public class ServiceInstallerOptions
    {
        private readonly ISet<Assembly> _assemblies = new HashSet<Assembly>();
        private readonly ISet<IServiceInstaller> _installers = new HashSet<IServiceInstaller>();

        public IEnumerable<Assembly> Assemblies => _assemblies;
        public IEnumerable<IServiceInstaller> Installers => _installers;

        public ServiceInstallerOptions AddAssemblyContaining<T>()
            => AddAssembly(typeof(T).GetTypeInfo().Assembly);

        public ServiceInstallerOptions AddAssemblyContaining(Type type)
            => AddAssembly(type.GetTypeInfo().Assembly);

        public ServiceInstallerOptions AddAssembly(Assembly assembly)
        {
            if (!_assemblies.Contains(assembly))
                _assemblies.Add(assembly);

            return this;
        }

        public ServiceInstallerOptions AddInstaller<TInstaller>() where TInstaller : IServiceInstaller, new()
            => AddInstaller(new TInstaller());

        public ServiceInstallerOptions AddInstaller(IServiceInstaller installer)
        {
            if (_installers.All(o => o.GetType() != installer.GetType()))
                _installers.Add(installer);

            return this;
        }

        public ServiceInstallerOptions AddInstallers(params IServiceInstaller[] installers)
        {
            foreach (var installer in installers)
                AddInstaller(installer);
            return this;
        }

        public ServiceInstallerOptions AddInstallersFromAssemblyOf<T>()
        {
            var installers =
                typeof(T).GetTypeInfo()
                    .Assembly.GetExportedTypes()
                    .Where(
                        t =>
                            !t.GetTypeInfo().IsAbstract &&
                            t.GetTypeInfo().GetInterfaces().Contains(typeof(IServiceInstaller)));

            foreach (var type in installers)
            {
                var installer = Activator.CreateInstance(type) as IServiceInstaller;
                AddInstaller(installer);
            }
            return this;
        }
    }
}