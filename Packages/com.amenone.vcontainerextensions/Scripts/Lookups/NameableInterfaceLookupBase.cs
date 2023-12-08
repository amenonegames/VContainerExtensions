using System.Collections.Generic;
using System.Linq;
using amenone.vcontainerextensions.Lookups.Interface;
using VContainer;

namespace amenone.vcontainerextensions.Lookups
{
    public abstract class NameableHashSetBase<T> : IViewHashSet<T>
    {
        [Inject]
        protected NameableHashSetBase(IRegistrable[] list)
        {
            _hash = list
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