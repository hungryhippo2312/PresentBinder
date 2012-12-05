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

        public PresentListOverviewViewModel(PresentList presentList)
        {
            _presentList = presentList;
        }

        public string ListName
        {
            get
            {
                return _presentList.Name;
            }
        }

        public string Notes
        {
            get
            {
                return _presentList.Notes;
            }
        }

        public int NumberOfPresents
        {
            get
            {
                return _presentList.Presents.Count;
            }
        }

        public PresentList PresentList { get { return _presentList; } }
    }
}
