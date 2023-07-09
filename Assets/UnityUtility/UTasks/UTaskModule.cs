using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility.Singleton;

namespace UnityUtility.UTasks
{
    public class UTaskModule : SingletonModule<UTaskModule>
    {
        private const int CAPACITY = 256;
        
        internal List<UTask> tasks = new List<UTask>(CAPACITY);
        internal Queue<UTask> taskPool = new Queue<UTask>(CAPACITY);
        
        private void Awake()
        {
            if(IsInstanceSetupBefore()) return; 
            for (var i = 0; i < CAPACITY; i++)
            {
                var t = new UTask(i);
                taskPool.Enqueue(t);
            }
        }
        private void Update()
        {
            for (int i = tasks.Count - 1; i >= 0; i--)
            {
                
                if (tasks[i] == null || tasks[i].updater == null || tasks[i].isFinished)
                {
                    tasks.RemoveAt(i);
                    continue;
                }
                else if (tasks[i].isPaused)
                {
                    continue;
                }
                
                
                tasks[i].updater.Update(tasks[i]);
            }
        }
        
        
    }
}