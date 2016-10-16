using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorUtils: Editor  {

    [MenuItem("Tools/Create FontCollection Collection")]
    public static void CreateFontCollection() {

        FontCollection fontCollection = CreateInstance<FontCollection>();
        AssetDatabase.CreateAsset(fontCollection,"Assets/Fonts/font.asset");
        AssetDatabase.SaveAssets();


    }





}
