using DontForgetThePresents.Core;
using GalaSoft.MvvmLight;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;
using System.ComponentModel;
using DontForgetThePresents.Core.Exceptions;

namespace DontForgetThePresents.ViewModel
{
    public class EditableListViewModel : ViewModelBase, IEditableObject
    {
        private readonly IPresentListRepository _listRepository;
        private readonly PresentList _list;
        private PresentList _originalList;

        [UsedImplicitly]
        public RelayCommand SaveCommand { get; private set; }

        public EditableListViewModel(IPresentListRepository listRepository, PresentList list)
        {
            _listRepository = listRepository;
            _list = list;

            SaveCommand = new RelayCommand(SavePresent, CanSavePresent);
            
            BeginEdit();
        }

        private void SavePresent()
        {
            try
            {
                _listRepository.Save(_list);
                EndEdit();
                Messenger.Default.Send(new GoToPreviousViewModel());
            }
            catch (RepositoryException)
            {
                CancelEdit();

                var message = new DisplayErrorSavingDataMessage();
                Messenger.Default.Send(message);
            }
        }

        private bool CanSavePresent()
        {
            return true;
        }

        [UsedImplicitly]
        public string Name
        {
            get
            {
                return _list.Name;
            }
            set
            {
                if (_list.Name != value)
                {
                    _list.Name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        [UsedImplicitly]
        public string Notes
        {
            get
            {
                return _list.Notes;
            }
            set
            {
                if (_list.Notes != value)
                {
                    _list.Notes = value;
                    RaisePropertyChanged("Notes");
                }
            }
        }

        public void BeginEdit()
        {
            _originalList = new PresentList
            {
                Name = _list.Name,
                Notes = _list.Notes
            };
        }

        public void CancelEdit()
        {
            if (_originalList != null)
            {
                Name = _originalList.Name;
                Notes = _originalList.Notes;
            }
        }

        public void EndEdit()
        {
            _originalList = null;
        }
    }
}
