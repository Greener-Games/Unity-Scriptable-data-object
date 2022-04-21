#region

using System;
using System.IO;
using System.Reflection;
using UnityEngine;

#endregion

namespace GG.ScriptableDataAsset
{
    public abstract partial class ScriptableDataAsset<T> : ScriptableObject where T : ScriptableDataAsset<T>
    {
        const string Assets = "assets/";
        const string SavePathFormat = "{0}Resources/{1}.asset";
        
        static readonly bool HasCustomPath = typeof(T).IsDefined(typeof(ScriptableDataAssetSettingsAttribute), true);

        /// <summary>
        ///     Local reference to the object
        /// </summary>
        static T LocalAsset;

        /// <summary>
        ///     Static reference to the asset in question
        /// </summary>
        public static T Asset
        {
            get
            {
                if (LocalAsset == null)
                {
                    CreateAndLoadAsset();
                }

                return LocalAsset;
            }
        }

        /// <summary>
        ///     Load the asset out of resources
        /// </summary>
        /// <returns></returns>
        static T CreateAndLoadAsset()
        {
            string path = GetFileName();
            
            LocalAsset = Resources.Load(path) as T;

            // Create it if it doesn't exist
            if (LocalAsset == null)
            {
                LocalAsset = CreateInstance<T>();
                LocalAsset.OnCreated();
                
                // And save it back out if appropriate
                Save();
            }
            
            return LocalAsset;
        }

        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            if (Application.isPlaying)
                OnLoaded();
#else
            OnLoaded();
#endif
        }
        
        /// <summary>
        ///     Function called when all scriptable settings are loaded and ready for use
        /// </summary>
        protected virtual void OnLoaded()
        { }

        /// <summary>
        ///     Function called when a new asset is created
        /// </summary>
        protected virtual void OnCreated()
        { }
        
        /// <summary>
        ///  Get the filename for this ScriptableSettings
        /// </summary>
        /// <returns>The filename</returns>
        static string GetFileName()
        {
            ScriptableDataAssetSettingsAttribute pathSettingsAttribute = typeof(T).GetCustomAttribute<ScriptableDataAssetSettingsAttribute>(true);
            if (HasCustomPath && pathSettingsAttribute != null && !string.IsNullOrEmpty(pathSettingsAttribute.Name))
            {
                return pathSettingsAttribute.Name;
            }
            else
            {
                //just return the name of the type
                Type type = typeof(T);
                return type.Name;
            }
        }

    }
}