using System.Collections.Generic;
using System.Linq;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.DataAccess
{
    public class MockListRepository : IPresentListRepository
    {
        public IEnumerable<PresentList> GetAllLists()
        {
            var lists =  new List<PresentList>();
            lists.Add(new PresentList() { Id = 1, Name = "Anniversary" });
            lists.Add(new PresentList() { Id = 2, Name = "Christmas - Philippa" });
            lists.Add(new PresentList() { Id = 3, Name = "Christmas - Mum" });
            lists.Add(new PresentList() { Id = 4, Name = "Christmas - Dad" });
            lists.Add(new PresentList() { Id = 5, Name = "Christmas - Diddy" });

            return lists.AsEnumerable<PresentList>();
        }
    }
}
