using System;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel
{
    public class ErrorSavingDataViewModel : ViewModelBase
    {
        public ErrorSavingDataViewModel()
        {
            Console.WriteLine("In the constructor.");
        }
        
        public string Description
        {
            get { return "There was an error saving the data."; }
        }

        public override string ToString()
        {
            return "ErrorSavingDataViewModel ToString()";
        }
    }
}
