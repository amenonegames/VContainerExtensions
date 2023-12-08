using System;
using System.Linq;
using VContainer;
using VContainer.Unity;

namespace amenone.vcontainerextensions
{
    public static class LifetimeScopeExtensions
    {
        public static void RegisterComponentOrNullObjectFromArray<RegisterType, NullType>(
            this IContainerBuilder builder, IRegistrable[] bindables)
        {
            var component = bindables.OfType<RegisterType>().SingleOrDefault();

            if (component == null)
                builder.Register<NullType>(Lifetime.Singleton)
                    .As<RegisterType>();
            else
                builder.RegisterComponent(component)
                    .As<RegisterType>();
        }

        public static void RegisterComponentFromBindables<RegisterType>(this IContainerBuilder builder,
            IRegistrable[] bindables, bool AsImplementedInterfaces = false)
        {
            var component = bindables.OfType<RegisterType>().SingleOrDefault();

            if (component == null) throw new Exception($"Component of type {typeof(RegisterType)} is not found");

            if (AsImplementedInterfaces)
                builder.RegisterComponent(component)
                    //.As<RegisterType>()
                    .AsImplementedInterfaces();
            else
                builder.RegisterComponent(component)
                    .As<RegisterType>();
        }
    }
}