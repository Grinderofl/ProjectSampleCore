using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public class InstallerContext : IInstallerContext
    {
        public InstallerContext(IEnumerable<Assembly> assemblies)
        {
            Assemblies = assemblies.ToArray();
        }

        public Assembly[] Assemblies { get; }
    }
}