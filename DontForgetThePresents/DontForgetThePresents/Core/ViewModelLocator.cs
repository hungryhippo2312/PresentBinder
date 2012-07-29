using System.Dynamic;

namespace DontForgetThePresents.Core
{
    public class ViewModelLocator : DynamicObject
    {
        public IWindsorResolver Resolver { get; set; }

        public ViewModelLocator()
        {
            Resolver = new ViewModelResolver();
        }

        public object this[string viewModelName]
        {
            get
            {
                return Resolver.Resolve(viewModelName);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = this[binder.Name];
            return true;
        }
    }
}