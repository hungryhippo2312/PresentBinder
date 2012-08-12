using System.Collections.Generic;
using DontForgetThePresents.Models;
using NHibernate;

namespace DontForgetThePresents.DataAccess
{
    public class PresentListRepository : IPresentListRepository
    {
        private ISession _session;

        public PresentListRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<PresentList> GetAllLists()
        {
            return _session.CreateCriteria<PresentList>().List<PresentList>();
        }
    }
}
