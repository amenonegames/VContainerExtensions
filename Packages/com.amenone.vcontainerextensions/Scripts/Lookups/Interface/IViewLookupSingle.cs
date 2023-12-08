using System.Collections.Generic;

namespace amenone.vcontainerextensions.Lookups.Interface
{
    public interface IViewLookupSingle<TKey, TValue>
    {
        TValue Get(TKey name);
        IEnumerable<TValue> GetAll();

        IEnumerable<TValue> GetExcept(TKey name);
        (TValue match, IEnumerable<TValue> except) GetMatchAndExcept(TKey name);
    }
    
    public interface IViewLookupSingleInstanceFromList< TKeyInList , TValue >
    {
        IEnumerable<TValue> Get(TKeyInList name);
        IEnumerable<TValue> GetAll();
        IEnumerable<TValue> GetExcept(TKeyInList name);
        (TValue match, IEnumerable<TValue> except) GetMatchAndExcept(TKeyInList name);
        bool ContainsKey(TKeyInList name);
    }
}