using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.NHibernate;
using Castle.Transactions;
using DontForgetThePresents.Core.Exceptions;
using DontForgetThePresents.Models;
using NHibernate;
using NHibernate.Linq;

namespace DontForgetThePresents.DataAccess
{
    public class PresentListRepository : IPresentListRepository
    {
        private readonly ISessionManager _sessionManager;

        public PresentListRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        [Transaction]
        public virtual IEnumerable<PresentList> GetAllLists()
        {
            using (ISession session = _sessionManager.OpenSession())
            {
                try
                {
                    return session.Query<PresentList>()
                        .FetchMany(pl => pl.Presents)
                        .ToList();
                }
                catch (HibernateException ne)
                {
                    Console.WriteLine(ne.Message);
                    throw new RepositoryException();
                }
            }
        }

        [Transaction]
        public virtual void Save(PresentList presentList)
        {
            using (ISession session = _sessionManager.OpenSession())
            {
                try
                {
                    session.SaveOrUpdate(presentList);
                }
                catch (HibernateException e)
                {
                    Console.WriteLine(e.Message);
                    throw new RepositoryException();
                }
            }
        }
    }
}
