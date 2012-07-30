using System.Collections.Generic;
using System.Collections.ObjectModel;
using DontForgetThePresents.Core;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace DontForgetThePresents.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public MainWindowViewModel(IAllListsViewModelFactory allListsViewModelFactory)
        {
            CurrentViewModel = allListsViewModelFactory.Create();

            Messenger.Default.Register<ViewModelBase>(this, ChangeCurrentViewModel);
        }

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
        }
    }
}