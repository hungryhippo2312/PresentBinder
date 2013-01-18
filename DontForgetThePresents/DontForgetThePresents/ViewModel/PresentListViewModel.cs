using System.Collections.Generic;
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

        public RelayCommand EditCommand { get; private set; }

        public PresentListViewModel(PresentList presentList, IPresentListRepository listRepository, IViewModelFactory viewModelFactory)
        {
            _presentList = presentList;
            _listRepository = listRepository;
            _viewModelFactory = viewModelFactory;

            EditCommand = new RelayCommand(() => EditPresent());
        }

        private void EditPresent()
        {
            var vm = _viewModelFactory.CreateEditableListViewModel(_listRepository, _presentList);
            Messenger.Default.Send(new GoToViewModel(vm));
        }

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

        public int NumberOfPresents
        {
            get
            {
                return _presentList.Presents.Count;
            }
        }

        public IList<PresentSummaryViewModel> Presents
        {
            get
            {
                List<PresentSummaryViewModel> presentSummaries = new List<PresentSummaryViewModel>();
                foreach (Present present in _presentList.Presents)
                {
                    PresentSummaryViewModel vm = _viewModelFactory.CreatePresentSummaryViewModel(present);
                    presentSummaries.Add(vm);
                }
                return presentSummaries;
            }
        }
    }
}
