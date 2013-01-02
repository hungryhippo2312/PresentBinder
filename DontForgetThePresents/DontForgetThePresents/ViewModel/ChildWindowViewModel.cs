﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;
using DontForgetThePresents.Core;

namespace DontForgetThePresents.ViewModel
{
    public class ChildWindowViewModel : ViewModelBase
    {
        private readonly IViewModelFactory _viewModelFactory;

        public ChildWindowViewModel(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;

            Messenger.Default.Register<DisplayErrorSavingDataMessage>(this,
                                                                      (msg) => CurrentContent = _viewModelFactory.CreateErrorSavingDataViewModel());
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
