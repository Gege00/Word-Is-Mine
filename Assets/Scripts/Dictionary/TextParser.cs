using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


#if UNITY_EDITOR
public class TextParser {


    public static void ParseTextAsset(TextAsset text) {

        List<string>[] dictionaryArray = new List<string>[4];
        for (int i = 0; i < 4; i++) {
            dictionaryArray[i] = new List<string>();
        }
        string[] words = text.text.Split(',');
        foreach (var w in words) {
            if (w.Length > 2 && w.Length < 7) {
                dictionaryArray[w.Length - 3].Add(w);
                Debug.Log(w.Length + "-" + w);
            }
        }
        WordCollection dic = ScriptableObject.CreateInstance<WordCollection>();
        for (int i = 0; i < 4; i++) {

            dic.WordDictionary.Add(i + 3, new WordArray(dictionaryArray[i].ToArray()));

        }
      UnityEditor.AssetDatabase.CreateAsset(dic, "Assets/Dictionary/words.asset");
      UnityEditor.AssetDatabase.SaveAssets();


    }
}
#endif




