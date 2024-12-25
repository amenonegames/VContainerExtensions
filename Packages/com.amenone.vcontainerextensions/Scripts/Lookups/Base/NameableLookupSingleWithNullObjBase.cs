using System;
using System.Collections.Generic;
using System.Linq;
using amenone.VcontainerExtensions.Identifier;
using amenone.VcontainerExtensions.Lookups.Interface;
using amenone.VcontainerExtensions.Lookups.Storage;
using UnityEngine;
using VContainer;

namespace amenone.VcontainerExtensions.Lookups
{
    public abstract class
        NameableLookupSingleBase<TKey, TValue , TValueNull> : IViewLookupSingle<TKey, TValue>
        where TValue : INameable<TKey> where TKey : IComparable where TValueNull : TValue ,new()
    {
        [Inject]
        protected NameableLookupSingleBase(IRegisterMarkerStorage list)
        {
            _dictionary = list.RegisterMarkers
                .OfType<TValue>()
                .ToDictionary(x => x.Name);
        }

        protected Dictionary<TKey, TValue> _dictionary { get; }

        public TValue Get(TKey name)
        {
            if (!_dictionary.TryGetValue(name, out var value))
            {
                Debug.Log(name + "is not found in lookup. return null Object");
                return new TValueNull();
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
            TValue match = new TValueNull();

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