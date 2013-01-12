namespace DontForgetThePresents.ViewModel.ChildWindowViewModels
{
    public class ErrorOccurredViewModel : ChildWindowViewModelBase
    {
        public override string Title { get { return "Error"; } }

        public string Description { get; set; }
    }
}
