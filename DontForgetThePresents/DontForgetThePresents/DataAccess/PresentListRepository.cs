using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.NHibernate;
using Castle.Transactions;
using DontForgetThePresents.Models;
using NHibernate;
using NHibernate.Linq;

namespace DontForgetThePresents.DataAccess
{
    public class PresentListRepository : IPresentListRepository
    {
        private ISessionManager _sessionManager;

        public PresentListRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        [Transaction]
        public virtual IEnumerable<PresentList> GetAllLists()
        {
            using (ISession session = _sessionManager.OpenSession())
            {
                return session.Query<PresentList>()
                    .FetchMany(pl => pl.Presents)
                    .ToList<PresentList>();
            }
        }

        [Transaction]
        public virtual bool Save(PresentList presentList)
        {
            using (ISession session = _sessionManager.OpenSession())
            {
                try
                {
                    session.SaveOrUpdate(presentList);
                    throw new Exception("Exception thrown when saving list.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
