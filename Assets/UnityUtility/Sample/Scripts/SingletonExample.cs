using System;
using UnityEngine;
using UnityUtility.Singleton;

namespace UnityUtility.Sample.Scripts
{
    public class SingletonExample : SingletonModule<SingletonExample>
    {
        private void Awake()
        {
            if (Instance.IsInstanceSetupBefore()) return;
            Debug.Log("Singleton is working fine:" +  Instance.name);
        }
    }
}
