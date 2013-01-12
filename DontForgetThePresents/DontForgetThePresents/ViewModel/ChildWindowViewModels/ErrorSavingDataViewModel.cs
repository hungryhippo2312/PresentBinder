using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel.ChildWindowViewModels
{
    public class ErrorSavingDataViewModel : ViewModelBase
    {
        public string Description
        {
            get { return "There was an error saving the data."; }
        }
    }
}
