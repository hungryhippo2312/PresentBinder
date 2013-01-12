using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DontForgetThePresents.Core;
using DontForgetThePresents.Core.Exceptions;
using DontForgetThePresents.Core.Messenger;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace DontForgetThePresents.ViewModel
{
    public class AllListsViewModel : ViewModelBase
    {
        private readonly IPresentListRepository _listRepository;
        private readonly IViewModelFactory _viewModelFactory;

        public RelayCommand NewListCommand { get; private set; }
        public RelayCommand ShowPresentsCommand { get; private set; }

        public AllListsViewModel(IPresentListRepository listRepository, IViewModelFactory viewModelFactory)
        {
            _listRepository = listRepository;
            _viewModelFactory = viewModelFactory;

            NewListCommand = new RelayCommand(() => CreateNewList());
            ShowPresentsCommand = new RelayCommand(() => ShowPresents());
        }

        private void CreateNewList()
        {
            var vm = _viewModelFactory.CreateEditableListViewModel(_listRepository, new PresentList());
            GoToViewModel goToViewModel = new GoToViewModel(vm);
            Messenger.Default.Send<GoToViewModel>(goToViewModel);
        }

        public ObservableCollection<PresentListOverviewViewModel> PresentLists
        {
            get
            {
                var presentListVms = new ObservableCollection<PresentListOverviewViewModel>();
                try
                {
                    IEnumerable<PresentList> presentLists = _listRepository.GetAllLists();
                    foreach (PresentList pl in presentLists)
                    {
                        var vm = _viewModelFactory.CreatePresentListOverviewViewModel(pl);
                        presentListVms.Add(vm);
                    }
                }
                catch (RepositoryException)
                {
                    var message = new DisplayErrorRetrievingDataMessage();
                    Messenger.Default.Send(message);
                }
                
                return presentListVms;
            }
        }

        private PresentListOverviewViewModel _selectedList;
        public PresentListOverviewViewModel SelectedList
        {
            get
            {
                return _selectedList;
            }
            set
            {
                if (_selectedList != value)
                {
                    _selectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }

        private void ShowPresents()
        {
            PresentList list = _selectedList.PresentList;
            PresentListViewModel vm = _viewModelFactory.CreatePresentListViewModel(list);
            var goToViewModel = new GoToViewModel(vm);
            Messenger.Default.Send<GoToViewModel>(goToViewModel);
        }
    }
}
