using UnityEngine;

namespace GG.ScriptableDataAsset
{
    /// <summary>
    /// Holder class for editor save callback
    /// </summary>
    public static class SaveCallback
    {
        public delegate void Save(ScriptableObject asset, string path);
        public static Save save;
    }
}