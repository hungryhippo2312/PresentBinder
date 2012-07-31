using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DontForgetThePresents.ViewModel;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.Core
{
    public interface IPresentListViewModelFactory
    {
        PresentListViewModel Create(PresentList presentList);
    }
}
