using System.Collections.Generic;

namespace amenone.VcontainerViewExtensions.Lookups.Interface
{
    public interface IViewHashSet<T>
    {
        IEnumerable<T> GetAll();
    }
}