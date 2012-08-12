using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Facilities.NHibernate;
using FluentNHibernate.Cfg;
using Castle.Services.Transaction;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using DontForgetThePresents.Models.ClassMaps;

namespace DontForgetThePresents.Core
{
    public class FluentNHibernateInstaller : INHibernateInstaller
    {
        public FluentConfiguration BuildFluent()
        {
            return Fluently.Configure()
                .Database(SetupDatabase)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PresentMap>());

        }

        private IPersistenceConfigurer SetupDatabase()
        {
            return MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c
                    .Server("STU-PC\\SQLEXPRESS")
                    .Database("PresentBinder")
                    .Username("PresentBinder")
                    .Password("This is where all of your great ideas are stored!"));
        }

        public Maybe<IInterceptor> Interceptor
        {
            get { return Maybe.None<IInterceptor>(); }
        }

        public bool IsDefault
        {
            get { return true; }
        }

        public void Registered(ISessionFactory factory)
        {
            
        }

        public string SessionFactoryKey
        {
            get { return "sf.default"; }
        }
    }
}
