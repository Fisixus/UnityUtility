using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

using Object = UnityEngine.Object;

namespace UnityUtility.Serializations
{
    
    public class DataWizard<T> where T: new()
    {
        
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ReferenceLoopHandling =
                ReferenceLoopHandling.Ignore,
            Culture = CultureInfo.InvariantCulture,
            ConstructorHandling = ConstructorHandling
                .AllowNonPublicDefaultConstructor,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Include,
            ObjectCreationHandling = ObjectCreationHandling.Auto,
        };
        
        private static readonly string PATH_NAME = "RecordingData";
        

        public static T Load(string filename, string filePath = "")
        {
            if (filePath.Length > 0)
            {
                if(filePath[0] == '/')
                    filePath = filePath.Remove(0,1);
                if (filePath[filePath.Length - 1] == '/')
                    filePath = filePath.Remove(filePath.Length - 1);
            }

            string persistentDataPath = Application.persistentDataPath + "/" + PATH_NAME;
            if (!AssetDatabaseSupporters.IsFileExists(persistentDataPath + "/" + filePath, filename))
                throw new Exception("There is no file such this name.");
            filePath = persistentDataPath + "/" + filePath + "/" + filename;
            Debug.Log(filePath);
            FileStream inputStream = new FileStream(filePath, 
                FileMode.Open, 
                FileAccess.Read, 
                FileShare.Read, 64 * 1024,
                (FileOptions)0x20000000 | 
                FileOptions.WriteThrough & FileOptions.SequentialScan);
            string fileContents;
            using (StreamReader reader = new StreamReader(inputStream))
            {
                fileContents = reader.ReadToEnd();
            }
            var t = JsonConvert.DeserializeObject<T>(fileContents, settings);
            return t;
        }
        
        public static void Save(string filename, T value, string filePath = "")
        {
            if (filePath.Length > 0)
            {
                if(filePath[0] == '/')
                    filePath = filePath.Remove(0,1);
                if (filePath[filePath.Length - 1] == '/')
                    filePath = filePath.Remove(filePath.Length - 1);
            }
            string persistentDataPath = Application.persistentDataPath + "/" + PATH_NAME;
            var files = filePath.Split(new Char [] {'/' } );
            string path = "";
            foreach (var file in files)
            {
                path += "/" + file;
                AssetDatabaseSupporters.CreateMkdir(persistentDataPath + path);
            }
            
            filePath = persistentDataPath + "/" + filePath + "/" + filename;
            Debug.Log("f2:" + filePath);
            FileStream dataStream = new FileStream(filePath, FileMode.Create);
            
            var newJSONValue = JsonConvert.SerializeObject(value, Formatting.None,
                settings);
            Debug.Log("f3:" + newJSONValue);
            using (StreamWriter writer = new StreamWriter(dataStream))
            {
                writer.WriteLine(newJSONValue);
            }
        }
        
    }
}
