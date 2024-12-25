using amenone.VcontainerViewExtensions.Identifier;

namespace amenone.VcontainerViewExtensions.Utils
{
    public interface IBar : INameable<string>
    {
        void Execute();
    }
}