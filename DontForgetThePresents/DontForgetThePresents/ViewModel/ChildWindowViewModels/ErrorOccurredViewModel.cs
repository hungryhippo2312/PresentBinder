using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel.ChildWindowViewModels
{
    public class ErrorOccurredViewModel : ViewModelBase
    {
        public string Title { get { return "Error"; } }

        public string Description { get; set; }
    }
}
