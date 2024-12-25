using System.Linq;
using amenone.VcontainerViewExtensions.Lookups.Storage;
using VContainer;
using VContainer.Unity;

namespace amenone.VcontainerViewExtensions.Utils
{
    public class SampleLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // this sample is get component from autoInjectGameObjects. but you can use any other way to get component.
            var registerableMarkers = 
                autoInjectGameObjects.Select(x => x.GetComponents<IRegisterMarker>())
                    .SelectMany(x => x)
                    .Distinct()
                    .ToArray();
            
            // register one component inherit IFoo interface from array, if not found register FooAsNull 
            builder.RegisterComponentOrNullObFromArray<IFoo, IFooAsNullObj>(registerableMarkers);

            
            // register lookup to find some components inherit IBar interface 
            // first register IRegisterMarker[]
            builder.RegisterInstance(registerableMarkers)
                .As<IRegisterMarker[]>();

            // second register RegisterMarkerStorage
            builder.Register<RegisterMarkerStorage>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            // and register lookup
            builder.Register<BarLookup>(Lifetime.Singleton)
                .AsImplementedInterfaces();
            
            
        }
    }
}