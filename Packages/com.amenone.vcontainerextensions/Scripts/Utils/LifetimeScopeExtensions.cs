using System;
using System.Linq;
using Packages.com.amenone.vcontainerextensions.AdditionalUtils;
using VContainer;
using VContainer.Unity;

namespace amenone.vcontainerextensions
{
    public static class LifetimeScopeExtensions
    {
        public static RegistrationBuilder RegisterComponentOrNullObFromArray<TToFind, NullT>(
            this IContainerBuilder builder, IRegistrable[] bindables, bool asSelf = true , bool asImplementedInterfaces = false)
        {
            var component = bindables.OfType<TToFind>().SingleOrDefault();

            RegistrationBuilder registrationBuilder;
            if (component == null)
                registrationBuilder = builder.Register<NullT>(Lifetime.Singleton);
            else
                registrationBuilder = builder.RegisterComponentWithoutSelf(component);

            if( asSelf )
                registrationBuilder.AsSelf();
            
            if (asImplementedInterfaces)
                registrationBuilder.AsImplementedInterfaces();

            return registrationBuilder;
        }

        public static RegistrationBuilder RegisterComponentFromArray<TToFind>(this IContainerBuilder builder,
            IRegistrable[] bindables, bool asSelf , bool asImplementedInterfaces = false)
        {
            var component = bindables.OfType<TToFind>().SingleOrDefault();

            if (component == null) throw new Exception($"Component of type {typeof(TToFind)} is not found");

            RegistrationBuilder registrationBuilder;
            registrationBuilder = builder.RegisterComponentWithoutSelf(component);
            
            if(asSelf)
                registrationBuilder.AsSelf();
            
            if (asImplementedInterfaces)
                registrationBuilder.AsImplementedInterfaces();

            return registrationBuilder;
        }

    }
}