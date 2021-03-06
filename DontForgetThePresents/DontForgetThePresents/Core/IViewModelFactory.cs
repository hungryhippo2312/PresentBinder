﻿using DontForgetThePresents.DataAccess;
using DontForgetThePresents.Models;
using DontForgetThePresents.ViewModel;
using DontForgetThePresents.ViewModel.ChildWindowViewModels;

namespace DontForgetThePresents.Core
{
    public interface IViewModelFactory
    {
        #region List view models

        AllListsViewModel CreateAllListsViewModel();
        PresentListOverviewViewModel CreatePresentListOverviewViewModel(PresentList presentList);
        PresentListViewModel CreatePresentListViewModel(PresentList presentList);
        EditableListViewModel CreateEditableListViewModel(IPresentListRepository listRepository, PresentList list);

        #endregion

        #region Present view models

        PresentSummaryViewModel CreatePresentSummaryViewModel(Present present);
        EditablePresentViewModel CreateEditablePresentViewModel(Present present, PresentList list);

        #endregion

        #region Child window view models

        void CreateChildWindowViewModel(IViewModelFactory viewModelFactory);
        ErrorOccurredViewModel CreateErrorOccuredViewModel();

        #endregion
    }
}
