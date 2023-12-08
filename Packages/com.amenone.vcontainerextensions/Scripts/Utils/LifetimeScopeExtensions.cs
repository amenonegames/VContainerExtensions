using System;
using System.Linq;
using VContainer;
using VContainer.Unity;

namespace amenone.vcontainerextensions
{
    public static class LifetimeScopeExtensions
    {
        public static RegistrationBuilder RegisterComponentOrNullObFromArray<RegisterType, NullType>(
            this IContainerBuilder builder, IRegistrable[] bindables, bool AsImplementedInterfaces = false)
        {
            var component = bindables.OfType<RegisterType>().SingleOrDefault();

            RegistrationBuilder registrationBuilder;
            if (component == null)
                registrationBuilder = builder.Register<NullType>(Lifetime.Singleton)
                    .As<RegisterType>();
            else
                registrationBuilder = builder.RegisterComponent(component)
                    .As<RegisterType>();

            if (AsImplementedInterfaces)
                return registrationBuilder.AsImplementedInterfaces();
            else
                return registrationBuilder;
        }

        public static RegistrationBuilder RegisterComponentFromArray<RegisterType>(this IContainerBuilder builder,
            IRegistrable[] bindables, bool AsImplementedInterfaces = false)
        {
            var component = bindables.OfType<RegisterType>().SingleOrDefault();

            if (component == null) throw new Exception($"Component of type {typeof(RegisterType)} is not found");

            if (AsImplementedInterfaces)
                return builder.RegisterComponent(component)
                    //.As<RegisterType>()
                    .AsImplementedInterfaces();
            else
                return builder.RegisterComponent(component)
                    .As<RegisterType>();
        }
    }
}