using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using amenone.vcontainerextensions.identifier;
using amenone.vcontainerextensions.Lookups.Interface;
using UnityEngine;
using VContainer;

namespace amenone.vcontainerextensions.Lookups
{
    public abstract class
        ListNameableLookupSingleBase<TKeyInList,  TValue > : IViewLookupSingleInstanceFromList<TKeyInList, TValue >
        where TValue : IListNameable<TKeyInList> 
    {
        protected Dictionary<IEnumerable<TKeyInList>, TValue> _dictionary { get; }
        private List<TKeyInList> _AllKeys { get; }
        
        [Inject]
        protected ListNameableLookupSingleBase(IRegistrable[] list)
        {
            _dictionary = list
                .OfType<TValue>()
                .ToDictionary(x => x.Names);
            
            _AllKeys = new List<TKeyInList>();
            foreach (var key in _dictionary.Select(x => x.Key)) _AllKeys.AddRange(key);
        }

        
        public IEnumerable<TValue> Get(TKeyInList name)
        {
            IEnumerable<KeyValuePair<IEnumerable<TKeyInList>,TValue>> result =  _dictionary.Where(x => x.Key.Contains(name));
            IEnumerable<TValue> returnResult = result.Select(x => x.Value);

            return returnResult;
        }

        public IEnumerable<TValue> GetAll()
        {
            return _dictionary.Values;
        }

        public IEnumerable<TValue> GetExcept(TKeyInList name)
        {
            List<TValue> except = new();

            foreach (var keyValue in _dictionary)
            {
                if (keyValue.Key.Equals(name)) continue;
                except.Add(keyValue.Value);
            }

            return except;
        }

        public (TValue match, IEnumerable<TValue> except) GetMatchAndExcept(TKeyInList name)
        {
            List<TValue> except = new();
            TValue match = default;

            foreach (var keyValue in _dictionary)
                if (keyValue.Key.Equals(name)) match = keyValue.Value;
                else except.Add(keyValue.Value);

            return (match, except);
        }

        public bool ContainsKey(TKeyInList name)
        {
            return _AllKeys.Contains(name);
        }

    }
}