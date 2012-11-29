using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using DontForgetThePresents.Models;
using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Core;

namespace DontForgetThePresents.ViewModel
{
    public class PresentListViewModel : ViewModelBase
    {
        private PresentList _presentList;
        private IPresentSummaryViewModelFactory _presentSummaryViewModelFactory;

        public PresentListViewModel(PresentList presentList, IPresentSummaryViewModelFactory presentSummaryViewModelFactory)
        {
            _presentList = presentList;
            _presentSummaryViewModelFactory = presentSummaryViewModelFactory;
        }

        public string ListName
        {
            get
            {
                return _presentList.Name;
            }
            set
            {
                if (_presentList.Name != value)
                {
                    _presentList.Name = value;
                    RaisePropertyChanged("ListName");
                }
            }
        }

        public string Notes
        {
            get
            {
                return _presentList.Notes;
            }
            set
            {
                if (_presentList.Notes != value)
                {
                    _presentList.Notes = value;
                    RaisePropertyChanged("Notes");
                }
            }
        }

        public int NumberOfPresents
        {
            get
            {
                return _presentList.Presents.Count;
            }
        }

        public IList<PresentSummaryViewModel> Presents
        {
            get
            {
                List<PresentSummaryViewModel> presentSummaries = new List<PresentSummaryViewModel>();
                foreach (Present present in _presentList.Presents)
                {
                    PresentSummaryViewModel vm = _presentSummaryViewModelFactory.Create(present);
                    presentSummaries.Add(vm);
                }
                return presentSummaries;
            }
        }
    }
}
