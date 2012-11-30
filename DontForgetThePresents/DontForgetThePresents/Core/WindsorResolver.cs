using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Facilities.AutoTx;
using Castle.Facilities.NHibernate;

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

            _container.AddFacility<AutoTxFacility>();
            _container.Register(
                Component.For<INHibernateInstaller>()
                .ImplementedBy<FluentNHibernateInstaller>());
            _container.AddFacility<NHibernateFacility>();

            _container.Register(
                Component.For<IPresentListOverviewViewModelFactory>()
                .AsFactory());

            _container.Register(
                Component.For<IAllListsViewModelFactory>()
                .AsFactory());

            _container.Register(
                Component.For<IPresentListViewModelFactory>()
                .AsFactory());

            _container.Register(
                Component.For<IPresentSummaryViewModelFactory>()
                .AsFactory());

            _container.Register(
                Component.For<IEditableListViewModelFactory>()
                .AsFactory());
        }
    }
}
