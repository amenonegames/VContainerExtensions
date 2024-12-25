using amenone.VcontainerExtensions.Identifier;
using UnityEngine;

namespace amenone.VcontainerExtensions.Utils
{
    public class Bar : MonoBehaviour , IBar , IRegisterMarker
    {
        private string _name = "BarInstance";
        public string Name => _name;

        public void Execute()
        {
            Debug.Log("Bar Execute");
        }

    }
}