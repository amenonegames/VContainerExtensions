using System;
using System.Collections.Generic;
using System.Linq;
using amenone.VcontainerViewExtensions.Identifier;
using amenone.VcontainerViewExtensions.Lookups.Interface;
using VContainer;

namespace amenone.VcontainerViewExtensions.Lookups
{
    public abstract class
        NameableLookupEnumerableBase<TKey, TValue> : IViewLookupEnumerable<TKey, TValue>
        where TValue : INameable<TKey> where TKey : IComparable
    {
        [Inject]
        protected NameableLookupEnumerableBase(IRegisterMarker[] list)
        {
            _Lookup = (Lookup<TKey, TValue>)list
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