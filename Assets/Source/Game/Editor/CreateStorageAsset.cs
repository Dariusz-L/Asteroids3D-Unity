using Core.Editor;
using Game.Scripts;
using UnityEditor;

namespace Game.Editor
{
    public class CreateStorageAsset
    {
        [MenuItem("Assets/Create/StorageAsset")]
        public static void CreateAsset() {
            ScriptableObjectUtility.CreateAsset<Storage>();
        }
    }
}
