using System;
using UnityEngine;
using UnityUtility.Serializations;

namespace UnityUtility.Sample.Scripts
{
    public class DataWizardExample : MonoBehaviour
    {
        private void Awake()
        {
            TestUtilityLevel tu = new TestUtilityLevel(); 
            DataWizard<TestUtilityLevel>.Save("TestSave",tu);
        }

        private void Start()
        {
            var t = DataWizard<TestUtilityLevel>.Load("TestSave");
            Debug.Log("Level:" + t.level);
            Debug.Log("Score:" + t.score);
        }
    }
}
