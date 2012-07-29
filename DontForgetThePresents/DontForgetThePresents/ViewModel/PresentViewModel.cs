using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using DontForgetThePresents.Models;

namespace DontForgetThePresents.ViewModel
{
    public class PresentViewModel : ViewModelBase
    {
        private Present _present;

        public PresentViewModel(Present present)
        {
            _present = present;
        }

        public String PresentName
        {
            get
            {
                return _present.Description;
            }
            set
            {
                if (value != _present.Description)
                {
                    _present.Description = value;
                    RaisePropertyChanged("PresentName");
                }
            }
        }
    }
}
