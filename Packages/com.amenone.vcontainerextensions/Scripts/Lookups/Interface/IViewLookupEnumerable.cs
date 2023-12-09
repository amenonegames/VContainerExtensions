using System.Collections.Generic;

namespace amenone.VcontainerViewExtensions.Lookups.Interface
{
    public interface IViewLookupEnumerable<TKey, TValue>
    {
        IEnumerable<TValue> Get(TKey name);
        IEnumerable<TValue> GetAll();
        IEnumerable<TValue> GetExcept(TKey name);
        (IEnumerable<TValue> match, IEnumerable<TValue> except) GetMatchAndExcept(TKey name);
    }
    
    public interface IViewLookupEnumerableFromList<TKeyInList, TValue>
    {
        IEnumerable<TValue> Get(TKeyInList name);
        IEnumerable<TValue> GetAll();
        IEnumerable<TValue> GetExcept(TKeyInList name);
        (IEnumerable<TValue> match, IEnumerable<TValue> except) GetMatchAndExcept(TKeyInList name);
        bool ContainsKey(TKeyInList name);
    }
}