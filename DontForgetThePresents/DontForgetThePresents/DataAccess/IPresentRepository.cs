using System.Collections.Generic;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.DataAccess
{
    public interface IPresentRepository
    {
        IEnumerable<Present> GetAll();
    }
}
