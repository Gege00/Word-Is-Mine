using UnityEngine;
using System.Collections;

[System.Serializable()]
public class WordDictionary : SerializableDictionaryBase<int, WordArray>
{


}

[System.Serializable()]
public class WordArray
{

    public string[] words;


    public WordArray(string[] words)
    {
        this.words = words;
    }


    public string GetRandomWorld()
    {
        return words[UnityEngine.Random.Range(0, words.Length)];
    }
}

