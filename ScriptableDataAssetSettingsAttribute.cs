using System;

namespace GG.ScriptableDataAsset
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ScriptableDataAssetSettingsAttribute : Attribute
    {
        /// <summary>
        /// The path where this ScriptableSettings should be stored
        /// </summary>
        public string Path { get; }
        
        /// <summary>
        /// The path where this ScriptableSettings should be stored
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initialize a new ScriptableSettingsPathAttribute
        /// </summary>
        /// <param name="path">The path where the ScriptableSettings should be stored</param>
        public ScriptableDataAssetSettingsAttribute(string path = "")
        {
            this.Path = path;
        }

        /// <summary>
        /// Initialize a new ScriptableSettingsPathAttribute
        /// </summary>
        /// <param name="path">The path where the ScriptableSettings should be stored</param>
        /// <param name="name">Name override for the Asset</param>
        public ScriptableDataAssetSettingsAttribute(string path = "", string name = "")
        {
            this.Path = path;
            this.Name = name;
        }
    }
}