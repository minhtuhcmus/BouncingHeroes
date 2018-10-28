using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR //Editor only tag
using UnityEditor;
#endif //Editor only tag
 
public class _3CSettingCreate {
#if UNITY_EDITOR //Editor only tag
    [MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        _3CSettings asset = ScriptableObject.CreateInstance<_3CSettings>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
#endif //Editor only tag
}
