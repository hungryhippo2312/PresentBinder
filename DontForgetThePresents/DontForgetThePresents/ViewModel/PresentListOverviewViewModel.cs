using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace DontForgetThePresents.ViewModel
{
    public class PresentListOverviewViewModel : ViewModelBase
    {
        private PresentList _presentList;

        public PresentListOverviewViewModel(PresentList presentList)
        {
            _presentList = presentList;

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
            //need to show a view model containing all of the presents in this list.
            Messenger.Default.Send<ViewModelBase>(this);
        }
    }
}
