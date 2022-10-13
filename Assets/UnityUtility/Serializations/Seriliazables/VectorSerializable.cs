using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace UnityUtility.Serializations.Serializables
{
    [System.Serializable]
    public class VectorSerializable
    {
        [JsonIgnore]
        public Vector3 v;
        public List<float> values = new List<float>(3);
        
        public VectorSerializable(){}

        public VectorSerializable(Vector3 v)
        {
            values.Clear();
            values.Add(v.x);
            values.Add(v.y);
            values.Add(v.z);
        }
        
    }
}
