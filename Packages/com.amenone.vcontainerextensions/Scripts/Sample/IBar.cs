using amenone.VcontainerExtensions.Identifier;

namespace amenone.VcontainerExtensions.Utils
{
    public interface IBar : INameable<string>
    {
        void Execute();
    }
}