using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DontForgetThePresents.ViewModel;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.Core
{
    public interface IEditableListViewModelFactory
    {
        EditableListViewModel Create(IPresentListRepository listRepository, PresentList list);
    }
}
