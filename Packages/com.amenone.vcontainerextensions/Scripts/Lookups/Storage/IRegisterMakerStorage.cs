using amenone.VcontainerExtensions.Identifier;

namespace amenone.VcontainerExtensions.Lookups.Storage
{
    public interface IRegisterMarkerStorage
    {
        IRegisterMarker[] RegisterMarkers { get; }
    }
}