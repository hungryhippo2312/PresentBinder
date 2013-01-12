using System;
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

            Messenger.Default.Register<DisplayErrorOccuredMessage>(this, HandleMessage);
        }

        private void HandleMessage(MessageBase message)
        {
            var vm = _viewModelFactory.CreateErrorOccurredViewModel();
            if (message is DisplayErrorSavingDataMessage)
            {
                vm.Description = "There was an error saving the data.";
            }
            else if (message is DisplayErrorRetrievingDataMessage)
            {
                vm.Description = "There was an error retrieving the data.";
            }
            else
            {
                throw new ArgumentException("unhandled message type", "message");
            }
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
