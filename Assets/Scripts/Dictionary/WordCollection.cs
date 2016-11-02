using UnityEngine;
using System.Collections;

public class WordCollection : ScriptableObject
{

    public WordDictionary WordDictionary = new WordDictionary();


    public string GetRandomWord(int wordLength)
    {
        return WordDictionary[wordLength].GetRandomWorld();
    }

}
