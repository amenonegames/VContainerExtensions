using amenone.VcontainerViewExtensions.Lookups;
using amenone.VcontainerViewExtensions.Lookups.Storage;

namespace amenone.VcontainerViewExtensions.Utils
{
    public class BarLookup : NameableLookupEnumerableBase<string,IBar>
    {
        public BarLookup(IRegisterMarkerStorage list) : base(list)
        {
        }
    }
}