namespace ProjectSampleCore.Infrastructure.DependencyInjection.ServiceInstaller
{
    public class ServiceInstallerExecutorFactory
    {
        private readonly ServiceInstallerOptions _options;

        public ServiceInstallerExecutorFactory(ServiceInstallerOptions options)
        {
            _options = options;
        }

        public ServiceInstallerExecutor Create()
        {
            var configuration = new InstallerContext(_options.Assemblies);
            var executor = new ServiceInstallerExecutor(configuration, _options.Installers);
            return executor;
        }
    }
}