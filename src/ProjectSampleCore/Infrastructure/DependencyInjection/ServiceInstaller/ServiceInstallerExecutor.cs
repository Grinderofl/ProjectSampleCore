using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public class ServiceInstallerExecutor
    {
        private readonly InstallerContext _context;
        private readonly IEnumerable<IServiceInstaller> _installers;

        public ServiceInstallerExecutor(InstallerContext context, IEnumerable<IServiceInstaller> installers)
        {
            _context = context;
            _installers = installers;
        }

        public void Execute(IServiceCollection services)
        {
            foreach(var installer in _installers)
                installer.Install(services, _context);
        }
    }
}