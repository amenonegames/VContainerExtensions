using VContainer;
using VContainer.Unity;

namespace Packages.com.amenone.vcontainerextensions.AdditionalUtils
{
    public static class ContainerBuilderUnityAdditionalExtensions
    {
        public static RegistrationBuilder RegisterComponentWithoutSelf<TInterface>(this IContainerBuilder builder, TInterface component)
        {
            var registrationBuilder = new ComponentRegistrationBuilder(component);
            // Force inject execution
            // builder.RegisterBuildCallback(container => container.Resolve<TInterface>());
            return builder.Register(registrationBuilder);
        }
    }
}