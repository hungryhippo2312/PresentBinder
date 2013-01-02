using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;
using System.ComponentModel;

namespace DontForgetThePresents.ViewModel
{
    public class EditableListViewModel : ViewModelBase, IEditableObject
    {
        private IPresentListRepository _listRepository;
        private PresentList _list;
        private PresentList _originalList;

        public RelayCommand SaveCommand { get; private set; }

        public EditableListViewModel(IPresentListRepository listRepository, PresentList list)
        {
            _listRepository = listRepository;
            _list = list;

            SaveCommand = new RelayCommand(() => SavePresent(), () => CanSavePresent());
            
            BeginEdit();
        }

        private void SavePresent()
        {
            try
            {
                _listRepository.Save(_list);
                EndEdit();
                Messenger.Default.Send<GoToPreviousViewModel>(new GoToPreviousViewModel());
            }
            catch (Exception e)
            {
                CancelEdit();
                Console.WriteLine("Caught exception in view model: " + e.Message);
                Messenger.Default.Send(new DisplayErrorSavingDataMessage());
            }
        }

        private bool CanSavePresent()
        {
            return true;
        }

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
