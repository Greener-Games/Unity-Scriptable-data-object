#if UNITY_EDITOR
#region

using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEditor;

#endregion

namespace GG.ScriptableDataAsset
{
    public abstract partial class ScriptableDataAsset<T>
    {
        /// <summary>
        ///  Save the asset to the database
        /// </summary>
        static void Save()
        {
            if (Application.isPlaying && !Application.isEditor)
            {
                // This is expected behavior so no log necessary here
                return;
            }

            if (LocalAsset == null)
            {
                Debug.Log("Cannot save: no instance!");
                return;
            }

            bool useDefaultPath = true;

            if (HasCustomPath)
            {
                ScriptableDataAssetSettingsAttribute pathSettingsAttribute = typeof(T).GetCustomAttribute<ScriptableDataAssetSettingsAttribute>(true);
                
                if (ValidatePath(SavePathFormat,pathSettingsAttribute.Path, GetFileName(), out string validatedPath))
                {
                    try
                    {
                        CreateAsset(validatedPath);
                        useDefaultPath = false;
                    }
                    catch (Exception e)
                    {
                        Debug.Log("unable to create asset at custom location, falling back to default");
                    }
                }
            }

            if (useDefaultPath)
            {
                ValidatePath(SavePathFormat, Assets, GetFileName(), out string validatedPath);
                CreateAsset(validatedPath);
            }

            if (!Application.isBatchMode)
            {
                EditorUtility.SetDirty(LocalAsset);
                AssetDatabase.SaveAssets();
            }
        }

        /// <summary>
        /// Builds a save path location for the new asset and validates core aspects of the path
        /// </summary>
        /// <param name="format"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="validated"></param>
        /// <returns></returns>
        static bool ValidatePath(string format, string path,string fileName, out string validated)
        {
            if (!path.StartsWith(Assets))
            {
                path = Assets + path;
            }

            if (!path.EndsWith("/"))
            {
                path += "/";
            }

            validated = string.Format(format, path, fileName);
            
            return true;
        }
        
        /// <summary>
        /// Create the Scriptable object and directory needed
        /// </summary>
        /// <param name="savePath"></param>
        static void CreateAsset(string savePath)
        {
            string folderPath = Path.GetDirectoryName(savePath);
            
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            AssetDatabase.CreateAsset(LocalAsset, savePath);
        }
    }
}
#endif