﻿using UnityEngine;

namespace amenone.VcontainerViewExtensions.Utils
{
    public class Foo : MonoBehaviour , IFoo , IRegisterMarker
    {
        public void Execute()
        {
            Debug.Log("Foo Execute");
        }
    }
    
}