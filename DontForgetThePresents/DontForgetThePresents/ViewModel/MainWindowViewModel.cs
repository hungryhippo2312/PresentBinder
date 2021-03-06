using System.Collections.Generic;
using DontForgetThePresents.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;

namespace DontForgetThePresents.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly List<ViewModelBase> _previousViewModels = new List<ViewModelBase>();

        [UsedImplicitly]
        public RelayCommand BackCommand { get; private set; }

        public MainWindowViewModel(IViewModelFactory viewModelFactory)
        {
            BackCommand = new RelayCommand(() => GoBackOneViewModel(new GoToPreviousViewModel()), CanGoBackOneViewModel);

            viewModelFactory.CreateChildWindowViewModel(viewModelFactory);
            
            var allListsVm = viewModelFactory.CreateAllListsViewModel();
            var goToAllListsVm = new GoToViewModel(allListsVm);
            ChangeCurrentViewModel(goToAllListsVm);

            Messenger.Default.Register<GoToViewModel>(this, ChangeCurrentViewModel);
            Messenger.Default.Register<GoToPreviousViewModel>(this, GoBackOneViewModel);
        }

        private void GoBackOneViewModel(GoToPreviousViewModel back)
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
        [UsedImplicitly]
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

        private void ChangeCurrentViewModel(GoToViewModel goToViewModel)
        {
            var viewModel = goToViewModel.ViewModel;
            CurrentViewModel = viewModel;
            _previousViewModels.Add(viewModel);
        }
    }
}