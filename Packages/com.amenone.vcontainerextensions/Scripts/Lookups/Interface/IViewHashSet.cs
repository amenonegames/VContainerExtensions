using System.Collections.Generic;

namespace amenone.VcontainerExtensions.Lookups.Interface
{
    public interface IViewHashSet<T>
    {
        IEnumerable<T> GetAll();
    }
}