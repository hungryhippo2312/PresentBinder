using Castle.MicroKernel.Registration;
using Castle.Facilities.Logging;

namespace DontForgetThePresents.Core.Windsor.Installers
{
    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.AddFacility<LoggingFacility>(f => f.UseNLog());
        }
    }
}
