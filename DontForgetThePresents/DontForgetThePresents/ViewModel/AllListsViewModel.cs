using System.Collections.ObjectModel;
using System.Linq;
using Castle.Core.Logging;
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

        [UsedImplicitly]
        public RelayCommand NewListCommand { get; private set; }
        [UsedImplicitly]
        public RelayCommand ShowPresentsCommand { get; private set; }
        [UsedImplicitly]
        public ILogger Logger { get; set; }

        public AllListsViewModel(IPresentListRepository listRepository, IViewModelFactory viewModelFactory)
        {
            _listRepository = listRepository;
            _viewModelFactory = viewModelFactory;

            NewListCommand = new RelayCommand(CreateNewList);
            ShowPresentsCommand = new RelayCommand(ShowPresents);
        }

        private void CreateNewList()
        {
            Logger.Debug("Creating new list.");
            var vm = _viewModelFactory.CreateEditableListViewModel(_listRepository, new PresentList());
            Messenger.Default.Send(new GoToViewModel(vm));
        }

        [UsedImplicitly]
        public ObservableCollection<PresentListOverviewViewModel> PresentLists
        {
            get
            {
                var presentListVms = new ObservableCollection<PresentListOverviewViewModel>();
                try
                {
                    var presentLists = _listRepository.GetAllLists();
                    foreach (var vm in presentLists.Select(pl => _viewModelFactory.CreatePresentListOverviewViewModel(pl)))
                    {
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
        [UsedImplicitly]
        public PresentListOverviewViewModel SelectedList
        {
            get
            {
                return _selectedList;
            }
            set
            {
                if (_selectedList == value)
                {
                    return;
                }
                _selectedList = value;
                RaisePropertyChanged("SelectedList");
            }
        }

        private void ShowPresents()
        {
            var vm = _viewModelFactory.CreatePresentListViewModel(_selectedList.PresentList);
            Messenger.Default.Send(new GoToViewModel(vm));
        }
    }
}
