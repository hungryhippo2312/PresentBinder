using DontForgetThePresents.Core;
using DontForgetThePresents.Core.Messenger;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace DontForgetThePresents.ViewModel.ChildWindowViewModels
{
    public class ChildWindowViewModel : ViewModelBase
    {
        private readonly IViewModelFactory _viewModelFactory;

        public ChildWindowViewModel(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;

            Messenger.Default.Register<DisplayErrorSavingDataMessage>(this, (msg) => CurrentContent = _viewModelFactory.CreateErrorSavingDataViewModel());
            Messenger.Default.Register<DisplayErrorRetrievingDataMessage>(this, (msg) => CurrentContent = _viewModelFactory.CreateErrorRetrievingDataViewModel());
        }

        private ViewModelBase _currentContent;
        public ViewModelBase CurrentContent
        {
            get
            {
                return _currentContent;
            }
            set
            {
                _currentContent = value;
                RaisePropertyChanged("CurrentContent");

                if (_currentContent != null)
                {
                    Messenger.Default.Send(new ShowChildWindowMessage());
                }
            }
        }
    }
}
