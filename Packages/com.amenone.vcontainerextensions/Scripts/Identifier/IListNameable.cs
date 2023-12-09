using System.Collections.Generic;

namespace amenone.VcontainerViewExtensions.Identifier
{
    public interface IListNameable<T> 
    {
        IEnumerable<T> Names { get; }
    }
}