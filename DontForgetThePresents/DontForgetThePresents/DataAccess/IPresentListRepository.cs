using System.Collections.Generic;
using DontForgetThePresents.Models;
using Castle.Transactions;

namespace DontForgetThePresents.DataAccess
{
    public interface IPresentListRepository
    {
        [Transaction]
        IEnumerable<PresentList> GetAllLists();
        
        [Transaction]
        void Save(PresentList presentList);
    }
}
