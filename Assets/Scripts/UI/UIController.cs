using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    
    public  Text wordText;




    public void SetText(string word) {
        wordText.text = word;
    }


    public void Reset() {
        wordText.text = "";
    }



}
