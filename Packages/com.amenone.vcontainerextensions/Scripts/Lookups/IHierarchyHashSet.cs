using System.Collections.Generic;

namespace amenone.vcontainerextensions
{
    public interface IHierarchyHashSet<T>
    {
        IEnumerable<T> GetAll();
    }
}