using VContainer;
using VContainer.Unity;

namespace amenone.VcontainerViewExtensions.AdditionalUtils
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