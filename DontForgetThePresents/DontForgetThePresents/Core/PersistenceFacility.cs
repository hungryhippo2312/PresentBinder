using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Facilities;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using DontForgetThePresents.Models.ClassMaps;
using Castle.MicroKernel.Registration;
using NHibernate;

namespace DontForgetThePresents.Core
{
    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            var config = BuildDatabaseConfiguration();

            Kernel.Register(
                Component.For<ISessionFactory>()
                .UsingFactoryMethod(_ => config.BuildSessionFactory()),
                Component.For<ISession>()
                .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                .LifestyleTransient()
                );
        }

        private Configuration BuildDatabaseConfiguration()
        {
            return Fluently.Configure()
                .Database(SetupDatabase)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PresentMap>())
                .BuildConfiguration();

        }

        protected virtual IPersistenceConfigurer SetupDatabase()
        {
            return MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c
                    .Server("STU-PC\\SQLEXPRESS")
                    .Database("PresentBinder")
                    .Username("PresentBinder")
                    .Password("This is where all of your great ideas are stored!"));
        }
    }
}
