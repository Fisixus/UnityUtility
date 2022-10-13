using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace UnityUtility.Extensions
{
    public class UnityExtensions
    {
    
        private static Random rng = new Random();

        //Fisher-Yates Shuffle
        public static void Shuffle<T>(IList<T> list) 
        {
        
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }

        public static bool CompareColors(Color color, Color color2)
        {
            return Mathf.Approximately(color.r, color2.r) && Mathf.Approximately(color.g, color2.g) &&
                   Mathf.Approximately(color.b, color2.b);
        }
    
        public static void SetLayerRecursively(GameObject obj, int newLayer)
        {
            if (null == obj)
            {
                return;
            }
       
            obj.layer = newLayer;
       
            foreach (Transform child in obj.transform)
            {
                if (null == child)
                {
                    continue;
                }
                SetLayerRecursively(child.gameObject, newLayer);
            }
        }

        public static IEnumerator WaitAndDoAction(Action a, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            a.Invoke();
        }
    
        public static float Remap (float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}