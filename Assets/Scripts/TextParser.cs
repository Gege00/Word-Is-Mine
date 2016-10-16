using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class WordDictionary: ScriptableObject {

   public string[] words;

}

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

        for (int i = 0; i < 4; i++) {
            var dic = ScriptableObject.CreateInstance<WordDictionary>();
            dic.words = dictionaryArray[i].ToArray();
            AssetDatabase.CreateAsset(dic,"Assets/Dictionary/"+i+"long-words.assets");
            
        }
        AssetDatabase.SaveAssets();


    }

 }



