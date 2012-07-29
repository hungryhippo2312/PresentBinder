using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace DontForgetThePresents.ViewModel
{
    public class PresentListViewModel : ViewModelBase
    {
        private PresentList _presentList;

        public PresentListViewModel(PresentList presentList)
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
            MessageBox.Show("Would show presents");
        }
    }
}
