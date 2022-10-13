using System;
using UnityEngine;

namespace UnityUtility.Sample.Scripts
{
    [Serializable]
    public class TestUtilityLevel
    {
        public int level;
        public double score;

        public TestUtilityLevel()
        {
            level = 1;
            score = 100;
        }
    }
}
