using System.Collections.Generic;
using DontForgetThePresents.Models;
using NHibernate;
using Castle.Transactions;
using Castle.Facilities.NHibernate;

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
                return session.QueryOver<PresentList>()
                    .Fetch(pl => pl.Presents)
                    .Eager
                    .List<PresentList>();
            }
        }
    }
}
