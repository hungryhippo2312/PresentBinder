namespace DontForgetThePresents.Core
{
    public interface IWindsorResolver
    {
        object Resolve(string viewModelName);
    }
}
