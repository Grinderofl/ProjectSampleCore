using Microsoft.Extensions.DependencyInjection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public interface IServiceInstaller
    {
        void Install(IServiceCollection services, IInstallerContext context);
    }
}
