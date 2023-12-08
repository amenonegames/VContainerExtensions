using System.Collections.Generic;

namespace amenone.vcontainerextensions.Lookups.Interface
{
    public interface IViewHashSet<T>
    {
        IEnumerable<T> GetAll();
    }
}