using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DontForgetThePresents.DataAccess;

namespace DontForgetThePresents.Core
{
    public class WindsorRepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPresentListRepository>().ImplementedBy<PresentListRepository>().LifestyleTransient());
            container.Register(Component.For<IPresentRepository>().ImplementedBy<PresentRepository>().LifestyleTransient());
        }
    }
}
