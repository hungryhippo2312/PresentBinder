using DontForgetThePresents.Models;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.ViewModel
{
    public class PresentSummaryViewModel : ViewModelBase
    {
        private readonly Present _present;

        public PresentSummaryViewModel(Present present)
        {
            _present = present;
        }

        public string Description
        {
            get
            {
                return _present.Description;
            }
        }
    }
}
