using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace amenone.vcontainerextensions
{
    public abstract class
        ListNameableInterfaceHierarchyLookupEnumerableBase<TKey, TKeyInList, TValue > : IHierarchyLookupEnumerableFromList<TKeyInList, TValue>
        where TValue : IListNameable<TKeyInList> where TKey : IEnumerable<TKeyInList> , IEnumerable
    {
        private ILookup<IEnumerable<TKeyInList>, TValue> _Lookup { get; }
        private List<TKeyInList> _AllKeys { get; }
        
        [Inject]
        protected ListNameableInterfaceHierarchyLookupEnumerableBase(IRegistrableStorage list)
        {
            
            _Lookup = list.Registrables
                .OfType<TValue>()
                .ToLookup(x => x.Names);
            
            _AllKeys = new List<TKeyInList>();
            foreach (var key in _Lookup.Select(x => x.Key))
            {
                if(key is null) continue;
                _AllKeys.AddRange(key);
            }
        }
        

        public IEnumerable<TValue> Get(TKeyInList name)
        {
            return _Lookup.Where(x => x.Key.Contains(name)).SelectMany(x => x);
        }

        public IEnumerable<TValue> GetAll()
        {
            return _Lookup.SelectMany(x => x);
        }
        
        public IEnumerable<TValue> GetExcept(TKeyInList name)
        {
            List<TValue> except = new();

            foreach (var keyValue in _Lookup)
            {
                if (keyValue.Key.Contains(name)) continue;
                except.AddRange(keyValue);
            }

            return except;
        }

        public (IEnumerable<TValue> match, IEnumerable<TValue> except) GetMatchAndExcept(TKeyInList name)
        {
            var except = new List<TValue>();
            List<TValue> match = new();

            foreach (var keyValue in _Lookup)
                if (keyValue.Key.Contains(name)) match.AddRange(keyValue);
                else except.AddRange(keyValue);

            return (match, except);
        }
        
        public bool ContainsKey(TKeyInList name)
        {
            return _AllKeys.Contains(name);
        }
    }
}