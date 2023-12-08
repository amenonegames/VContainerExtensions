using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace amenone.vcontainerextensions
{
    public abstract class
        NameableInterfaceHierarchyLookupSingleBase<TKey, TValue> : IHierarchyLookupSingleInstance<TKey, TValue>
        where TValue : INameable<TKey> where TKey : IComparable
    {
        [Inject]
        protected NameableInterfaceHierarchyLookupSingleBase(IRegistrableStorage list)
        {
            _dictionary = list.Registrables
                .OfType<TValue>()
                .ToDictionary(x => x.Name);
        }

        protected Dictionary<TKey, TValue> _dictionary { get; }

        public TValue Get(TKey name)
        {
            if (!_dictionary.TryGetValue(name, out var value))
            {
                Debug.Log(name + "is not found in lookup");
                return default;
            }

            return value;
        }

        public IEnumerable<TValue> GetAll()
        {
            return _dictionary.Values;
        }

        public IEnumerable<TValue> GetExcept(TKey name)
        {
            List<TValue> except = new();

            foreach (var keyValue in _dictionary)
            {
                if (keyValue.Key.Equals(name)) continue;
                except.Add(keyValue.Value);
            }

            return except;
        }

        public (TValue match, IEnumerable<TValue> except) GetMatchAndExcept(TKey name)
        {
            List<TValue> except = new();
            TValue match = default;

            foreach (var keyValue in _dictionary)
                if (keyValue.Key.Equals(name)) match = keyValue.Value;
                else except.Add(keyValue.Value);

            return (match, except);
        }

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
        }
    }
}