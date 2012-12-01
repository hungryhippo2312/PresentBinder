using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Core;
using System.Collections.ObjectModel;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;
using NHibernate;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core.Messenger;

namespace DontForgetThePresents.ViewModel
{
    public class AllListsViewModel : ViewModelBase
    {
        private readonly IPresentListRepository _listRepository;
        private readonly IPresentListOverviewViewModelFactory _presentListOverviewViewModelFactory;
        private readonly IEditableListViewModelFactory _editableListViewModelFactory;

        public RelayCommand NewListCommand { get; private set; }

        public AllListsViewModel(IPresentListRepository listRepository, IPresentListOverviewViewModelFactory presentListViewModelFactory,
                                 IEditableListViewModelFactory editableListViewModelFactory)
        {
            _listRepository = listRepository;
            _presentListOverviewViewModelFactory = presentListViewModelFactory;
            _editableListViewModelFactory = editableListViewModelFactory;

            NewListCommand = new RelayCommand(() => CreateNewList());
        }

        private void CreateNewList()
        {
            var vm = _editableListViewModelFactory.Create(_listRepository, new PresentList());
            GoToViewModel goToViewModel = new GoToViewModel(vm);
            Messenger.Default.Send<GoToViewModel>(goToViewModel);
        }

        public ObservableCollection<PresentListOverviewViewModel> PresentLists
        {
            get
            {
                var presentListVms = new ObservableCollection<PresentListOverviewViewModel>();
                IEnumerable<PresentList> presentLists = _listRepository.GetAllLists();
                foreach (PresentList pl in presentLists)
                {
                    var vm = _presentListOverviewViewModelFactory.Create(pl);
                    presentListVms.Add(vm);
                }

                return presentListVms;
            }
        }
    }
}
