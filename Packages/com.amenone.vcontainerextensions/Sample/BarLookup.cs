using amenone.VcontainerExtensions.Lookups;
using amenone.VcontainerExtensions.Lookups.Storage;

namespace amenone.VcontainerExtensions.Utils
{
    public class BarLookup : NameableLookupEnumerableBase<string,IBar>
    {
        public BarLookup(IRegisterMarkerStorage list) : base(list)
        {
        }
    }
}