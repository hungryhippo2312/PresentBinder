using DontForgetThePresents.Core;

namespace DontForgetThePresents.ViewModel.ChildWindowViewModels
{
    public class ErrorOccurredViewModel : ChildWindowViewModelBase
    {
        public override string Title { get { return "Error"; } }

        [UsedImplicitly]
        public string Description { get; set; }
    }
}
