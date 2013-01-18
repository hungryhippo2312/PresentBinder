﻿using System.Linq;
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
                _container = new WindsorContainer();
                ConfigureContainer();
            }

            var viewModelType =
                GetType()
                    .Assembly
                    .GetTypes().FirstOrDefault(t => t.Name.Equals(viewModelName));

            return _container.Resolve(viewModelType);
        }

        private void ConfigureContainer()
        {
            _container.Install(new WindsorViewsInstaller());
            _container.Install(new WindsorRepositoriesInstaller());

            _container.AddFacility<AutoTxFacility>();
            _container.Register(
                Component.For<INHibernateInstaller>()
                .ImplementedBy<FluentNHibernateInstaller>()
                .LifestylePerThread());
            _container.AddFacility<NHibernateFacility>();

            _container.Register(
                Component.For<IViewModelFactory>()
                .AsFactory());
        }
    }
}
