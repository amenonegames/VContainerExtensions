﻿using System;
using System.Collections.Generic;
using System.Linq;
using amenone.VcontainerExtensions.Identifier;
using amenone.VcontainerExtensions.Lookups.Interface;
using amenone.VcontainerExtensions.Lookups.Storage;
using VContainer;

namespace amenone.VcontainerExtensions.Lookups
{
    public abstract class
        NameableLookupEnumerableBase<TKey, TValue> : IViewLookupEnumerable<TKey, TValue>
        where TValue : INameable<TKey> where TKey : IComparable
    {
        [Inject]
        protected NameableLookupEnumerableBase(IRegisterMarkerStorage list)
        {
            _Lookup = (Lookup<TKey, TValue>)list.RegisterMarkers
                .OfType<TValue>()
                .ToLookup(x => x.Name);
        }

        private Lookup<TKey, TValue> _Lookup { get; }

        public IEnumerable<TValue> Get(TKey name)
        {
            return name == null ? null : _Lookup[name];
        }

        public IEnumerable<TValue> GetAll()
        {
            return _Lookup.SelectMany(x => x);
        }

        public IEnumerable<TValue> GetExcept(TKey name)
        {
            List<TValue> except = new();

            foreach (var keyValue in _Lookup)
            {
                if (keyValue.Key.Equals(name)) continue;
                except.AddRange(keyValue);
            }

            return except;
        }

        public (IEnumerable<TValue> match, IEnumerable<TValue> except) GetMatchAndExcept(TKey name)
        {
            List<TValue> except = new();
            IEnumerable<TValue> match = null;

            foreach (var keyValue in _Lookup)
                if (keyValue.Key.Equals(name)) match = keyValue;
                else except.AddRange(keyValue);

            return (match, except);
        }
    }
}