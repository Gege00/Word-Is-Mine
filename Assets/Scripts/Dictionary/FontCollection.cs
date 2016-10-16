using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum Alphabet {
    A='a',
    B='b',
    C='c',
    D='d',
    E='e',
    F='f',
    G='g',
    H='h',
    I='i',
    J='j',
    K='k',
    L='l',
    M='m',
    N='n',
    O='o',
    P='p',
    Q='q',
    R='r',
    S='s',
    T='t',
    U='u',
    V='v',
    W='w',
    X='x',
    Y='y',
    Z='z'
}
[Serializable]
public struct Character{

    public Alphabet c;
    public Texture2D texture;

    public Character(Alphabet c, Texture2D texture) {
        this.c = c;
        this.texture = texture;
    }
}

[Serializable]
public class FontCollection : ScriptableObject {


    public List<Character> font= new List<Character>();
    private int length;


    public Texture2D GetSprite(char c) {
        length = font.Count;
        for (int i = 0; i < length; i++) {

            if ((int)font[i].c==c) {
                return font[i].texture;
           }
        }
        return Texture2D.whiteTexture;
        
    }

}
