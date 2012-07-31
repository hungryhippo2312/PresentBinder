using DontForgetThePresents.Models;
using DontForgetThePresents.ViewModel;

namespace DontForgetThePresents.Core
{
    public interface IPresentViewModelFactory
    {
        PresentListOverviewViewModel Create(PresentList presentList);
    }
}
