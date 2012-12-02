using System.Collections.Generic;
using DontForgetThePresents.Models;
using Castle.Transactions;

namespace DontForgetThePresents.DataAccess
{
    public interface IPresentListRepository
    {
        IEnumerable<PresentList> GetAllLists();
        bool Save(PresentList presentList);
    }
}
