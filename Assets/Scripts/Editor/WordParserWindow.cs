using UnityEngine;
using System.Collections;
using UnityEditor;


public class WordParserWindow : EditorWindow {

    [MenuItem("Tools/Word Parser",false)]
    public static void GetWordParserWindow() {
        WordParserWindow wpw = GetWindow<WordParserWindow>();
        wpw.Show();
    }

    private TextAsset textFile;


    public void OnGUI() {

       textFile=EditorGUILayout.ObjectField(textFile, typeof (TextAsset),false) as TextAsset;

        if (textFile) {
            if (GUILayout.Button("Generate WordCollection asset")) {
                TextParser.ParseTextAsset(textFile);
            }
        }
    }

}

