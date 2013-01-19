using System.Configuration;
using Castle.Facilities.NHibernate;
using Castle.Transactions;
using DontForgetThePresents.Models.ClassMaps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using DontForgetThePresents.Properties;

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
            return MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public Maybe<IInterceptor> Interceptor
        {
            //get { return Maybe.None<IInterceptor>(); }
            get { return new SqlStatementInterceptor(); }
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
