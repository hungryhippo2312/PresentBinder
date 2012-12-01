using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using DontForgetThePresents.Core;
using DontForgetThePresents.Core.Messenger;

namespace DontForgetThePresents.ViewModel
{
    public class PresentListOverviewViewModel : ViewModelBase
    {
        private PresentList _presentList;
        private IPresentListViewModelFactory _presentListViewModelFactory;

        public PresentListOverviewViewModel(PresentList presentList, IPresentListViewModelFactory presentListViewModelFactory)
        {
            _presentList = presentList;
            _presentListViewModelFactory = presentListViewModelFactory;

            ShowPresentsCommand = new RelayCommand(ShowPresents);
        }

        public string ListName
        {
            get
            {
                return _presentList.Name;
            }
            set
            {
                if (value != _presentList.Name)
                {
                    _presentList.Name = value;
                    RaisePropertyChanged("ListName");
                }
            }
        }

        public RelayCommand ShowPresentsCommand { get; private set; }

        private void ShowPresents()
        {
            PresentListViewModel vm = _presentListViewModelFactory.Create(_presentList);
            var goToViewModel = new GoToViewModel(vm);
            Messenger.Default.Send<GoToViewModel>(goToViewModel);
        }
    }
}
