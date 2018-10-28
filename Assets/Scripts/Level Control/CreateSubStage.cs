using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR //Editor only tag
using UnityEditor;
#endif

public class CreateSubStage {
#if UNITY_EDITOR //Editor only tag
	[MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        SubStage_Data asset = ScriptableObject.CreateInstance<SubStage_Data>();

        AssetDatabase.CreateAsset(asset, "Assets/Substage.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
#endif
}
