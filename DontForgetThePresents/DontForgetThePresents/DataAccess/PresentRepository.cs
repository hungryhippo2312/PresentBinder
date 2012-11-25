using System.Collections.Generic;
using Castle.Facilities.NHibernate;
using DontForgetThePresents.Models;
using NHibernate;

namespace DontForgetThePresents.DataAccess
{
    public class PresentRepository : IPresentRepository
    {
        private ISessionManager _sessionManager;

        public PresentRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
    }
}
