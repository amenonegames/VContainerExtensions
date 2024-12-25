using System.Collections.Generic;

namespace amenone.VcontainerExtensions.Identifier
{
    public interface IListNameable<T> 
    {
        IEnumerable<T> Names { get; }
    }
}