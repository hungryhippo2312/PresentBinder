using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.ViewModel
{
    public class PresentListViewModel : ViewModelBase
    {
        private PresentList _presentList;

        public PresentListViewModel(PresentList presentList)
        {
            _presentList = presentList;
        }

        public string ListName
        {
            get
            {
                return _presentList.Name;
            }
            set
            {
                if (_presentList.Name != value)
                {
                    _presentList.Name = value;
                    RaisePropertyChanged("ListName");
                }
            }
        }

        public string Notes
        {
            get
            {
                return _presentList.Notes;
            }
            set
            {
                if (_presentList.Notes != value)
                {
                    _presentList.Notes = value;
                    RaisePropertyChanged("Notes");
                }
            }
        }
    }
}
