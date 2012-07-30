using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DontForgetThePresents.ViewModel;
using DontForgetThePresents.DataAccess;

namespace DontForgetThePresents.Core
{
    public interface IAllListsViewModelFactory
    {
        //AllListsViewModel Create(IPresentListRepository repository, IPresentViewModelFactory presentListViewModelFactory);
        AllListsViewModel Create();
    }
}
