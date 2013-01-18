using DontForgetThePresents.Core;
using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel
{
    public class PresentListOverviewViewModel : ViewModelBase
    {
        private readonly PresentList _presentList;

        public PresentListOverviewViewModel(PresentList presentList)
        {
            _presentList = presentList;
        }

        [UsedImplicitly]
        public string ListName
        {
            get
            {
                return _presentList.Name;
            }
        }

        [UsedImplicitly]
        public string Notes
        {
            get
            {
                return _presentList.Notes;
            }
        }

        [UsedImplicitly]
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
