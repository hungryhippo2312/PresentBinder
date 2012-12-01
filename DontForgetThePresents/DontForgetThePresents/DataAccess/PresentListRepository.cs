using System.Collections.Generic;
using DontForgetThePresents.Models;
using NHibernate;
using Castle.Transactions;
using Castle.Facilities.NHibernate;
using NHibernate.Linq;
using System.Linq;

namespace DontForgetThePresents.DataAccess
{
    public class PresentListRepository : IPresentListRepository
    {
        private ISessionManager _sessionManager;

        public PresentListRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public IEnumerable<PresentList> GetAllLists()
        {
            using (ISession session = _sessionManager.OpenSession())
            {
                return session.Query<PresentList>()
                    .FetchMany(pl => pl.Presents)
                    .ToList<PresentList>();
            }
        }

        public void Save(PresentList presentList)
        {
            using (ISession session = _sessionManager.OpenSession())
            using (session.BeginTransaction())
            {
                session.SaveOrUpdate(presentList);
                session.Transaction.Commit();
            }
        }
    }
}
