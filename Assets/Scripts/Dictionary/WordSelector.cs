using UnityEngine;
using System.Collections;


public struct CharacterData {
    public char c;
    public Texture2D texture;

    public CharacterData(char c, Texture2D texture) {
        this.c = c;
        this.texture = texture;
    }
}

[ExecuteInEditMode]
public class WordSelector : MonoBehaviour {


    public static WordSelector instance;
    public FontCollection fontCollection;
    public string word;
    public TextAsset text;


    void OnEnable() {
        instance = this;
    }

    public static CharacterData[] GetWord() {

        return instance.GetCharacters();
    }


   CharacterData[] GetCharacters() {
        word = word.ToLower();
        char[] characters = word.ToCharArray();
        CharacterData[] charData =new CharacterData[characters.Length];
        int length = charData.Length;
        for (int i = 0; i < length; i++) {
           Debug.Log(charData[i] =new CharacterData(characters[i],instance.fontCollection.GetSprite(characters[i])));
        }
        return charData;

   }


    


}
