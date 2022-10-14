using System;
using UnityEngine;
using UnityUtility.Events.ScriptableObjects;
using UnityUtility.UTasks;

namespace UnityUtility.Sample.Scripts
{
    public class UTaskExample : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO m_StartSO;

        private void Awake()
        {
            m_StartSO.OnEventRaised += StartUTasks;
        }

        private void OnDestroy()
        {
            m_StartSO.OnEventRaised -= StartUTasks;
        }

        private void StartUTasks()
        {
            //It will wait seconds that input indicated, then it'll run the Action
            UTask.Wait(5f).Do(() =>
            {
                Debug.Log("Wait is working");
            });
            
            //It will wait frames that input indicated, then it'll run the Action
            UTask.WaitFrames(60).Do(() =>
            {
                Debug.Log("WaitFrames is working");
            });

            //It will wait that Func<bool> condition is returned true, then it'll run the Action
            UTask.If(() => true).Do(() =>
            {
                Debug.Log("If is working");
            });

            //It'll run the action that repeatCount times on repeatGap intervals
            UTask.Repeat(10, 0.5f).Do(() =>
            {
                Debug.Log("Repeat is working");
            });
            
            
            //It will run the Action unless Func<bool> condition on while is returned false
            UTask.While(() => true).Do(() =>
            {
                Debug.Log("While is working");
            });
        }

    }
}
