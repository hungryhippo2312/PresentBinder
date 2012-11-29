using System.Collections.Generic;
using System.Collections.ObjectModel;
using DontForgetThePresents.Core;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System;

namespace DontForgetThePresents.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<ViewModelBase> _previousViewModels = new List<ViewModelBase>();
        public RelayCommand BackCommand { get; private set; }

        public MainWindowViewModel(IAllListsViewModelFactory allListsViewModelFactory)
        {
            BackCommand = new RelayCommand(() => GoBackOneViewModel(), () => CanGoBackOneViewModel());

            ChangeCurrentViewModel(allListsViewModelFactory.Create());

            Messenger.Default.Register<ViewModelBase>(this, ChangeCurrentViewModel);
        }

        private void GoBackOneViewModel()
        {
            //need to go back two view models because the current one is added to the list when it's displayed.
            ViewModelBase previousViewModel = _previousViewModels[_previousViewModels.Count - 2];
            ChangeCurrentViewModel(previousViewModel);
        }

        private bool CanGoBackOneViewModel()
        {
            //we always add the "all lists" view model to the history but you don't want to include that one
            //as that's the starting point and there's nothing to come before it.
            return _previousViewModels.Count > 1;
        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    RaisePropertyChanged("CurrentViewModel");
                }
            }
        }

        private void ChangeCurrentViewModel(ViewModelBase viewModel)
        {
            CurrentViewModel = viewModel;

            //"all lists" is the starting point so if we've made our way to it then we need to clear down the history and start again.
            if (viewModel is AllListsViewModel)
            {
                _previousViewModels.Clear();
            }
            
            _previousViewModels.Add(viewModel);
        }
    }
}