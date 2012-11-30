using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight.Command;

namespace DontForgetThePresents.ViewModel
{
    public class EditableListViewModel : ViewModelBase
    {
        private IPresentListRepository _listRepository;
        private PresentList _list;

        public RelayCommand SaveCommand { get; private set; }

        public EditableListViewModel(IPresentListRepository listRepository)
        {
            _listRepository = listRepository;
            _list = new PresentList();

            SaveCommand = new RelayCommand(() => SavePresent(), () => CanSavePresent());
        }

        private void SavePresent()
        {
            _listRepository.Save(_list);
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
    }
}
