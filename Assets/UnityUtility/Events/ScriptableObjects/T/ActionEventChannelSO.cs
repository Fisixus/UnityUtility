using System;
using UnityEngine;

namespace UnityUtility.Events.ScriptableObjects.T
{
    /// <summary>
    /// This class is used for Events that have one int argument.
    /// Example: An Achievement unlock event, where the int is the Achievement ID.
    /// </summary>

    [CreateAssetMenu(menuName = "Events/Action Event Channel")]
    public class ActionEventChannelSO : TEventChannelSO<Action>
    {
        
    }
}