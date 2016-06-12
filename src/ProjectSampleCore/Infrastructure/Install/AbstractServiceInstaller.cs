using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller;

namespace ProjectSampleCore.Infrastructure.Install
{
    public abstract class AbstractServiceInstaller : IServiceInstaller
    {
        protected virtual IEnumerable<Type> FindTypes(Assembly[] assemblies, params Type[] matchOn)
        {
            var types = assemblies.SelectMany(a => a.GetExportedTypes()).Where(t =>
            {
                var ti = t.GetTypeInfo();
                if (ti.IsAbstract)
                    return false;
                if (matchOn.Any(m => ti.IsSubclassOf(m) || ti.GetInterfaces().Any(i => i == m)))
                    return true;


                return false;
            });
            return types;
        }

        public abstract void Install(IServiceCollection services, IInstallerContext context);
    }
}
