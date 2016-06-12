using System.Reflection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public interface IInstallerContext
    {
        Assembly[] Assemblies { get; }
    }
}