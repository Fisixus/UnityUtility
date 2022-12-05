using UnityEngine;
using UnityEngine.Events;

namespace UnityUtility.Events.ScriptableObjects.TT
{
    /// <summary>
    /// This class is used for Events that have one int argument.
    /// Example: An Achievement unlock event, where the int is the Achievement ID.
    /// </summary>
    
    public class TTEventChannelSO<T,K> : ScriptableObject
    {
        public UnityAction<T,K> OnEventRaised;
        public void RaiseEvent(T value1, K value2)
        {
            OnEventRaised.Invoke(value1, value2);
        }
    }
}