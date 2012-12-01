using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace DontForgetThePresents.Core.Messenger
{
    public class GoToViewModel
    {
        private ViewModelBase _viewModel;

        public GoToViewModel(ViewModelBase viewModel)
        {
            _viewModel = viewModel;
        }

        public ViewModelBase ViewModel { get { return _viewModel; } }
    }
}
