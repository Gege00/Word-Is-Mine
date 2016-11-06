using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorUtils: Editor  {

    [MenuItem("Tools/Create FontCollection Collection")]
    public static void CreateFontCollection() {

        FontCollection fontCollection = CreateInstance<FontCollection>();
        fontCollection.Setup();
        AssetDatabase.CreateAsset(fontCollection,"Assets/Fonts/font.asset");
        AssetDatabase.SaveAssets();


    }


    [MenuItem("Tools/Create new difficultyLevel")]
    public static void CreateNewDiffLevel() {

        AssetDatabase.CreateAsset(CreateInstance<Difficulty>(), "Assets/Difficulties/NewDiff.asset");
        AssetDatabase.SaveAssets();

    }





}
