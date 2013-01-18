using NHibernate;
using System.Diagnostics;

namespace DontForgetThePresents.Core
{
    public class SqlStatementInterceptor : EmptyInterceptor
    {
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
            Debug.WriteLine(sql.ToString());
            return base.OnPrepareStatement(sql);
        }
    }
}
