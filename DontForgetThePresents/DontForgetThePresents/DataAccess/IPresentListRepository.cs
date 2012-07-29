using System.Collections.Generic;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.DataAccess
{
    public interface IPresentListRepository
    {
        IEnumerable<PresentList> GetAllLists();
    }
}
