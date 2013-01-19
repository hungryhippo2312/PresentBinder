using System.Diagnostics;
using NHibernate;
using Castle.Core.Logging;

namespace DontForgetThePresents.Core
{
    public class SqlStatementInterceptor : EmptyInterceptor
    {
        [UsedImplicitly]
        public ILogger Logger { get; set; }

        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            //Logger.Debug(sql.ToString());
            Trace.WriteLine(sql.ToString());
            return base.OnPrepareStatement(sql);
        }
    }
}
