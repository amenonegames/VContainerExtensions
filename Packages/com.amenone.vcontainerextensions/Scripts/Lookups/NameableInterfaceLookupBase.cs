using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace amenone.vcontainerextensions
{
    public abstract class InterfaceHashSetBase<T> : IHierarchyHashSet<T>
    {
        [Inject]
        protected InterfaceHashSetBase(IRegistrableStorage list)
        {
            _hash = list.Registrables
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