using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class WordCollection: ScriptableObject {

    public WordDictionary WordDictionary= new WordDictionary();


    public string GetRandomWord(int wordLength) {
        return  WordDictionary[wordLength].GetRandomWorld();
    }

}
[System.Serializable()]
public class WordDictionary : SerializableDictionaryBase<int,WordArray> {


}

[System.Serializable()]
public class WordArray {

    public string[] words;
    

    public WordArray(string[] words) {
        this.words = words;
    }


    public string GetRandomWorld() {
        return words[UnityEngine.Random.Range(0, words.Length)];
    }
}

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
        var dic = ScriptableObject.CreateInstance<WordCollection>();
        for (int i = 0; i < 4; i++) {

            dic.WordDictionary.Add(i + 3, new WordArray(dictionaryArray[i].ToArray()));

        }
      UnityEditor.AssetDatabase.CreateAsset(dic, "Assets/Dictionary/words.asset");
      UnityEditor.AssetDatabase.SaveAssets();


    }
}
#endif




