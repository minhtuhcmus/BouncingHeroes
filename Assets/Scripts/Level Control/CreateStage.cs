using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR //Editor only tag
using UnityEditor;
#endif

public class CreateStage {
#if UNITY_EDITOR //Editor only tag
	[MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        Stage_Data asset = ScriptableObject.CreateInstance<Stage_Data>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
#endif
}
