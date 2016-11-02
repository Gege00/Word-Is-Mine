using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

    public static MainController instance;



    public Player player;


    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else {
            DestroyImmediate(this);
        }
        
    }
   
}
