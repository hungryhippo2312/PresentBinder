using System.Collections.Generic;
using System.Collections.ObjectModel;
using DontForgetThePresents.Core;
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
