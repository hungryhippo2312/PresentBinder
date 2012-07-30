using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.Core
{
    public class ViewModelResolver : IWindsorResolver
    {
        private IWindsorContainer _container;

        public object Resolve(string viewModelName)
        {
            if (_container == null)
            {
                configureContainer();
            }

            var viewModelType =
                GetType()
                .Assembly
                .GetTypes()
                .Where(t => t.Name.Equals(viewModelName))
                .FirstOrDefault();

            return _container.Resolve(viewModelType);
        }

        private void configureContainer()
        {
            _container = new WindsorContainer();
            _container.Install(new WindsorViewsInstaller());
            _container.Install(new WindsorRepositoriesInstaller());

            _container.AddFacility<TypedFactoryFacility>();

            _container.Register(
                //Component.For<PresentList>(),
                Component.For<IPresentViewModelFactory>()
                .AsFactory());

            _container.Register(
                Component.For<IAllListsViewModelFactory>()
                .AsFactory());
        }
    }
}
