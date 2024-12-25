using System.Collections.Generic;
using System.Linq;
using amenone.VcontainerViewExtensions.Lookups.Interface;
using amenone.VcontainerViewExtensions.Lookups.Storage;
using VContainer;

namespace amenone.VcontainerViewExtensions.Lookups
{
    public abstract class NameableHashSetBase<T> : IViewHashSet<T>
    {
        [Inject]
        protected NameableHashSetBase(IRegisterMarkerStorage list)
        {
            _hash = list.RegisterMarkers
                .OfType<T>()
                .ToHashSet();
        }

        private HashSet<T> _hash { get; }

        public IEnumerable<T> GetAll()
        {
            return _hash;
        }
    }
}