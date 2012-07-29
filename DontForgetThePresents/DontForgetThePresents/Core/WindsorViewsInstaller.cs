using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.Core
{
    public class WindsorViewsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(
                    AllTypes.FromThisAssembly()
                    .BasedOn<ViewModelBase>()
                    .Configure(c => c.LifestyleTransient()));
        }
    }
}
