using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;

namespace DontForgetThePresents.ViewModel
{
    public class ChildWindowViewModel : ViewModelBase
    {
        public ChildWindowViewModel()
        {
            Messenger.Default.Register<DisplayErrorSavingDataMessage>(this,
                //(msg) => _childWindowViewModel.CurrentContent = _viewModelFactory.CreateErrorSavingDataViewModel());
                                                                      (msg) => Text = "Changed by something");
        }

        private string _text;// = "Hello from the child window view model";
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged("Text");
                Messenger.Default.Send(new ShowChildWindowMessage());

                //if (_currentContent != null)
                //{
                //    Messenger.Default.Send(new ShowChildWindowMessage());
                //}
            }
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
                //Messenger.Default.Send(new ShowChildWindowMessage());

                if (_currentContent != null)
                {
                    Messenger.Default.Send(new ShowChildWindowMessage());
                }
            }
        }
    }
}
