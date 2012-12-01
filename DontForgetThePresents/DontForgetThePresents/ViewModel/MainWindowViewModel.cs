using System.Collections.Generic;
using DontForgetThePresents.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

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

            _previousViewModels.RemoveAt(_previousViewModels.Count - 1);
            CurrentViewModel = previousViewModel;
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
            _previousViewModels.Add(viewModel);
        }
    }
}