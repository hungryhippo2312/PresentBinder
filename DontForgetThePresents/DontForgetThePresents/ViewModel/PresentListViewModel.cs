using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using DontForgetThePresents.Models;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Core;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;

namespace DontForgetThePresents.ViewModel
{
    public class PresentListViewModel : ViewModelBase
    {
        private readonly PresentList _presentList;
        private readonly IPresentListRepository _listRepository;
        private readonly IViewModelFactory _viewModelFactory;

        [UsedImplicitly]
        public RelayCommand EditCommand { get; private set; }
        public RelayCommand AddPresentCommand { get; private set; }

        public PresentListViewModel(PresentList presentList, IPresentListRepository listRepository, IViewModelFactory viewModelFactory)
        {
            _presentList = presentList;
            _listRepository = listRepository;
            _viewModelFactory = viewModelFactory;

            EditCommand = new RelayCommand(EditList);
            AddPresentCommand = new RelayCommand(AddPresent);
        }

        private void EditList()
        {
            var vm = _viewModelFactory.CreateEditableListViewModel(_listRepository, _presentList);
            Messenger.Default.Send(new GoToViewModel(vm));
        }

        private void AddPresent()
        {
            var vm = _viewModelFactory.CreateEditablePresentViewModel(new Present(), _presentList);
            Messenger.Default.Send(new GoToViewModel(vm));
        }

        [UsedImplicitly]
        public string ListName
        {
            get
            {
                return _presentList.Name;
            }
            set
            {
                if (_presentList.Name != value)
                {
                    _presentList.Name = value;
                    RaisePropertyChanged("ListName");
                }
            }
        }

        [UsedImplicitly]
        public string Notes
        {
            get
            {
                return _presentList.Notes;
            }
            set
            {
                if (_presentList.Notes != value)
                {
                    _presentList.Notes = value;
                    RaisePropertyChanged("Notes");
                }
            }
        }

        [UsedImplicitly]
        public int NumberOfPresents
        {
            get
            {
                return _presentList.Presents.Count;
            }
        }

        [UsedImplicitly]
        public IList<PresentSummaryViewModel> Presents
        {
            get
            {
                return _presentList.Presents.Select(present => _viewModelFactory.CreatePresentSummaryViewModel(present)).ToList();
            }
        }
    }
}
