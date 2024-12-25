using amenone.VcontainerExtensions.Identifier;
using UnityEngine;

namespace amenone.VcontainerExtensions.Utils
{
    public class Foo : MonoBehaviour , IFoo , IRegisterMarker
    {
        public void Execute()
        {
            Debug.Log("Foo Execute");
        }
    }
    
}