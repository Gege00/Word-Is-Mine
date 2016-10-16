using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(WordSelector))]
public class WordSelectorInspector :Editor {
    private WordSelector wordSelector;

    public override void OnInspectorGUI() {

        base.OnInspectorGUI();

        wordSelector=target as WordSelector;
        if (GUILayout.Button("GetWord")) {
            TextParser.ParseTextAsset(wordSelector.text);
        }
    }
}
