using DontForgetThePresents.Models;
namespace DontForgetThePresents.DataAccess
{
    public interface IPresentRepository
    {
        void Save(Present present, PresentList list);
    }
}
