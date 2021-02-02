using System;
using System.IO;
using UnityEngine;
using Object = System.Object;

namespace GG.ScriptableDataAsset
{
    public abstract class ScriptableDataAsset<T> : ScriptableObject where T : ScriptableDataAsset<T>
    {
        protected abstract string AssetName { get; }
        protected virtual string AssetPath => $"Assets/Resources/{AssetName}.asset";

        /// <summary>
        /// Static reference to the asset in question
        /// </summary>
        public static T Asset => LoadAsset();

        /// <summary>
        /// Load the asset out of resources
        /// </summary>
        /// <returns></returns>
        public static T LoadAsset()
        {
            T i = (T) Activator.CreateInstance(typeof(T));
            T dataAsset = Resources.Load<T>(i.AssetName);

            if (dataAsset == null)
            {
                dataAsset = CreateInstance<T>();
                EnsureResourcesExists();
                dataAsset.NewAsset(dataAsset);
                SaveCallback.save?.Invoke(dataAsset, i.AssetPath);
            }

            return dataAsset;
        }

        /// <summary>
        /// What to store in the new asset when it is created
        /// </summary>
        protected virtual void NewAsset(T asset)
        {
            
        }

        /// <summary>
        ///     Ensure the resources directory lives at 'Assets' level
        /// </summary>
        static void EnsureResourcesExists()
        {
            string path = Path.Combine("Assets", "Resources");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}