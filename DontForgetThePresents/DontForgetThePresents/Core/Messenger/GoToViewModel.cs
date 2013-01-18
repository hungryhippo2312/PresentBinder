using GalaSoft.MvvmLight;

namespace DontForgetThePresents.Core.Messenger
{
    public class GoToViewModel
    {
        private readonly ViewModelBase _viewModel;

        public GoToViewModel(ViewModelBase viewModel)
        {
            _viewModel = viewModel;
        }

        public ViewModelBase ViewModel { get { return _viewModel; } }
    }
}
