using Castle.Facilities.NHibernate;

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
