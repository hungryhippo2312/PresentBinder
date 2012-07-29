using System.Collections.Generic;
using System.Collections.ObjectModel;
using DontForgetThePresents.Core;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IPresentListRepository _repository;
        private readonly IPresentViewModelFactory _presentListViewModelFactory;

        public MainWindowViewModel(IPresentListRepository repository, IPresentViewModelFactory presentListViewModelFactory)
        {
            _repository = repository;
            _presentListViewModelFactory = presentListViewModelFactory;
        }

        public ObservableCollection<PresentListViewModel> PresentLists
        {
            get
            {
                var presentListVms = new ObservableCollection<PresentListViewModel>();
                IEnumerable<PresentList> presentLists = _repository.GetAllLists();
                foreach (PresentList pl in presentLists)
                {
                    var vm = _presentListViewModelFactory.Create(pl);
                    presentListVms.Add(vm);
                }

                return presentListVms;
            }
        }
    }
}