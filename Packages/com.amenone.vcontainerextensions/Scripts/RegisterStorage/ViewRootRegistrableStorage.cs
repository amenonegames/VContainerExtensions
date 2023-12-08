
namespace amenone.vcontainerextensions
{
    public class ViewRootRegistrableStorage : IRegistrableStorage
    {
        public IRegistrable[] Registrables { get; private set; }
        
        public ViewRootRegistrableStorage(IRegistrable[] registrables)
        {
            Registrables = registrables;
        }
    }
}