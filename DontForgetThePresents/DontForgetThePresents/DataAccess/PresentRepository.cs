using System;
using Castle.Core.Logging;
using Castle.Facilities.NHibernate;
using Castle.Transactions;
using DontForgetThePresents.Core;
using DontForgetThePresents.Core.Exceptions;
using DontForgetThePresents.Models;
using NHibernate;

namespace DontForgetThePresents.DataAccess
{
    public class PresentRepository : IPresentRepository
    {
        private readonly ISessionManager _sessionManager;

        public PresentRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        [UsedImplicitly]
        public ILogger Logger { get; set; }

        [Transaction]
        public void Save(Present present, PresentList list)
        {
            using (var session = _sessionManager.OpenSession())
            {
                try
                {
                    list.AddPresent(present);
                    session.SaveOrUpdate(present);
                }
                catch (HibernateException he)
                {
                    Logger.Error(he.Message, he);
                    throw new RepositoryException();
                }
            }
        }
    }
}
