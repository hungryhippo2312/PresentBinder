using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Core;
using System.Collections.ObjectModel;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel
{
    public class AllListsViewModel : ViewModelBase
    {
        private readonly IPresentListRepository _repository;
        private readonly IPresentListOverviewViewModelFactory _presentListOverviewViewModelFactory;

        public AllListsViewModel(IPresentListRepository repository, IPresentListOverviewViewModelFactory presentListViewModelFactory)
        {
            _repository = repository;
            _presentListOverviewViewModelFactory = presentListViewModelFactory;
        }

        public ObservableCollection<PresentListOverviewViewModel> PresentLists
        {
            get
            {
                var presentListVms = new ObservableCollection<PresentListOverviewViewModel>();
                IEnumerable<PresentList> presentLists = _repository.GetAllLists();
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
