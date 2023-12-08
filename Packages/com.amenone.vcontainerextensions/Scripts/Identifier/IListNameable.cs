using System.Collections;
using System.Collections.Generic;

namespace amenone.vcontainerextensions.identifier
{
    public interface IListNameable<T> 
    {
        IEnumerable<T> Names { get; }
    }
}