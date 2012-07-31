using DontForgetThePresents.Models;
using DontForgetThePresents.ViewModel;

namespace DontForgetThePresents.Core
{
    public interface IPresentListOverviewViewModelFactory
    {
        PresentListOverviewViewModel Create(PresentList presentList);
    }
}
