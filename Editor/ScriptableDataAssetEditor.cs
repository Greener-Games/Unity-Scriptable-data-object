using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GG.ScriptableDataAsset.Editor
{
    public class ScriptableDataAssetEditor
    {
        [InitializeOnLoadMethod]
        static void PopulateSaveMethod()
        {
            SaveCallback.save = Save;
        }

        /// <summary>
        /// save the scriptable object in the asset database if needed
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="path"></param>
        static void Save(ScriptableObject asset, string path)
        {
            AssetDatabase.CreateAsset(asset, path);
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
        }
    }
}