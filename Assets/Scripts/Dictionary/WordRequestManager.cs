using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public struct WordRequest {

    public int        difficultyLevel;
    public int        numberOfFakes;
    public Action<WordData>  callback;

    public WordRequest(int difficultyLevel, int numberOfFakes, Action<WordData> callback) {
        this.difficultyLevel = difficultyLevel;
        this.numberOfFakes   = numberOfFakes;
        this.callback        = callback;
    }
}

public struct WordData {
    public string word;
    public CharacterData[] charsData;

    public WordData(string word, CharacterData[] charsData) {
        this.word = word;
        this.charsData = charsData;
    }
}

public class WordRequestManager : MonoBehaviour {

    public WordCollection WordCollection;
    public FontCollection FontCollection;

    private static WordRequestManager instance;
    private Queue<WordRequest> requests=new Queue<WordRequest>();
    private bool isProcessing = false;
    private WordRequest currentWordRequest;



    void OnEnable() {
        instance = this;
    }


    public static void AddRequest(int diffLevel,int numberOfFakes, Action<WordData> callback) {
       instance.requests.Enqueue(new WordRequest(diffLevel,numberOfFakes,callback));
       instance.TryProcessNext();
    }

    public void FinishProcessingRequest(WordData wordData) {
        currentWordRequest.callback(wordData);
        isProcessing = false;
        TryProcessNext();
    }

    public void TryProcessNext() {
        if (!isProcessing && requests.Count > 0) {
            currentWordRequest = requests.Dequeue();
            isProcessing = true;
            StartCoroutine(ProcessRequests());
        }

    }

    public IEnumerator ProcessRequests() {
        yield return 0;
        string word = WordCollection.GetRandomWord(currentWordRequest.difficultyLevel);
        CharacterData[] charsData = FontCollection.GetCharacters(word);
        if (word != null && charsData.Length > 0) {
            FinishProcessingRequest(new WordData(word,charsData));
        }
    }


}
