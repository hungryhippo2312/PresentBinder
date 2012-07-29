using System.Collections.Generic;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.DataAccess
{
    public class MockPresentRepository : IPresentRepository
    {
        public IEnumerable<Present> GetAll()
        {
            var presents = new List<Present>();
            presents.Add(new Present() { Id = 1, ListId = 1, Description = "Anniversary present 1" });
            presents.Add(new Present() { Id = 2, ListId = 1, Description = "Anniversary present 2" });
            presents.Add(new Present() { Id = 3, ListId = 1, Description = "Anniversary present 3" });

            presents.Add(new Present() { Id = 4, ListId = 2, Description = "Philippa christmas present 1" });
            presents.Add(new Present() { Id = 5, ListId = 2, Description = "Philippa christmas present 2" });

            presents.Add(new Present() { Id = 7, ListId = 3, Description = "Mum christmas present 1" });

            presents.Add(new Present() { Id = 8, ListId = 4, Description = "Dad christmas present 1" });

            presents.Add(new Present() { Id = 9, ListId = 5, Description = "Diddy christmas present 1" });
            presents.Add(new Present() { Id = 10, ListId = 5, Description = "Diddy christmas present 2" });

            return presents;
        }
    }
}
