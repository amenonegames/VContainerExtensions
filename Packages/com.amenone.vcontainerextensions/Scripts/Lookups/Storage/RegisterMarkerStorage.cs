using System.Collections.Generic;
using System.Linq;

namespace amenone.VcontainerViewExtensions.Lookups.Storage
{
    public class RegisterMarkerStorage : IRegisterMarkerStorage
    {
        private IRegisterMarker[] _registerMarkers;

        public IRegisterMarker[] RegisterMarkers => _registerMarkers;

        public RegisterMarkerStorage( IReadOnlyList<IRegisterMarker> registerMarkers)
        {
            _registerMarkers = registerMarkers.ToArray();
        }
    }
}