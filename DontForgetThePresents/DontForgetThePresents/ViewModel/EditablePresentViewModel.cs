using DontForgetThePresents.Core.Messenger;
using GalaSoft.MvvmLight;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using DontForgetThePresents.Core;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace DontForgetThePresents.ViewModel
{
    public class EditablePresentViewModel : ViewModelBase
    {
        private readonly IPresentRepository _presentRepository;
        private readonly Present _present;
        private readonly PresentList _list;

        public EditablePresentViewModel(IPresentRepository presentRepository, Present present, PresentList list)
        {
            _presentRepository = presentRepository;
            _present = present;
            _list = list;

            SaveCommand = new RelayCommand(SavePresent);
        }

        [UsedImplicitly]
        public string Description
        {
            get
            {
                return _present.Description;
            }
            set
            {
                if (_present.Description == value)
                {
                    return;
                }
                _present.Description = value;
                RaisePropertyChanged("Description");
            }
        }

        [UsedImplicitly]
        public RelayCommand SaveCommand { get; private set; }

        private void SavePresent()
        {
            try
            {
                _presentRepository.Save(_present, _list);
                Messenger.Default.Send(new GoToPreviousViewModel());
            }
            catch
            {
                var message = new DisplayErrorSavingDataMessage();
                Messenger.Default.Send(message);
            }
        }
    }
}
