using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel.ChildWindowViewModels
{
    public abstract class ChildWindowViewModelBase : ViewModelBase
    {
        public abstract string Title { get; }
    }
}
