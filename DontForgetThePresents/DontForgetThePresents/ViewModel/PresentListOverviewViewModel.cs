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
