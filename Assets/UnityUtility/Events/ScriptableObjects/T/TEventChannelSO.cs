using UnityEngine;
using UnityEngine.Events;

namespace UnityUtility.Events.ScriptableObjects.T
{
    /// <summary>
    /// This class is used for Events that have one int argument.
    /// Example: An Achievement unlock event, where the int is the Achievement ID.
    /// </summary>
    
    public class TEventChannelSO<T> : ScriptableObject
    {
        public UnityAction<T> OnEventRaised;
        public void RaiseEvent(T value)
        {
            OnEventRaised.Invoke(value);
        }
    }
}