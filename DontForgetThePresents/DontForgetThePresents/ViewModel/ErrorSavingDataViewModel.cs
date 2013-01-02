using System;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel
{
    public class ErrorSavingDataViewModel : ViewModelBase
    {
        public string Description
        {
            get { return "There was an error saving the data."; }
        }
    }
}
