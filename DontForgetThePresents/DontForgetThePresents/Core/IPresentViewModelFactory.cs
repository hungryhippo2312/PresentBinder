using DontForgetThePresents.Models;
using DontForgetThePresents.ViewModel;

namespace DontForgetThePresents.Core
{
    public interface IPresentViewModelFactory
    {
        PresentListViewModel Create(PresentList presentList);
    }
}
