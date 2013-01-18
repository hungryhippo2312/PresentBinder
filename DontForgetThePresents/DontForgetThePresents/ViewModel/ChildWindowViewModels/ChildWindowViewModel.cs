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

            Messenger.Default.Register<DisplayErrorSavingDataMessage>(this, HandleMessage);
            Messenger.Default.Register<DisplayErrorRetrievingDataMessage>(this, HandleMessage);
        }

        private void HandleMessage(MessageBase message)
        {
            var vm = CreateViewModel(message);
            Title = vm.Title;
            CurrentContent = vm;

            Messenger.Default.Send(new ShowChildWindowMessage());
        }

        private ChildWindowViewModelBase CreateViewModel(MessageBase message)
        {
            if (MessageIsForError(message))
            {
                return CreateViewModelForError(message);
            }

            throw new ArgumentException("Unhandled message", "message");
        }

        private bool MessageIsForError(MessageBase message)
        {
            return message is DisplayErrorSavingDataMessage
                   || message is DisplayErrorRetrievingDataMessage;
        }

        private ChildWindowViewModelBase CreateViewModelForError(MessageBase message)
        {
            var errorVm = _viewModelFactory.CreateErrorOccuredViewModel();
            if (message is DisplayErrorSavingDataMessage)
            {
                errorVm.Description = "There was an error saving the data.";
            }
            else if (message is DisplayErrorRetrievingDataMessage)
            {
                errorVm.Description = "There was an error retrieving the data. Please try again.";
            }

            return errorVm;
        }

        private ChildWindowViewModelBase _currentContent;
        [UsedImplicitly]
        public ChildWindowViewModelBase CurrentContent
        {
            get
            {
                return _currentContent;
            }
            set
            {
                _currentContent = value;
                RaisePropertyChanged("CurrentContent");
            }
        }

        private string _title;
        [UsedImplicitly]
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }
    }
}
