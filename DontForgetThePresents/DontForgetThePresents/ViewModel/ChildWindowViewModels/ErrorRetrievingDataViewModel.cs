using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel.ChildWindowViewModels
{
    public class ErrorRetrievingDataViewModel : ViewModelBase
    {
        public string Description
        {
            get { return "There was an error retrieving the data. Please try again."; }
        }
    }
}
