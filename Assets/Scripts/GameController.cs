using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public static GameController instance;

    public GrenadeLauncher  GrenadeLauncher;
    public WordSelector     WordSelector;

    void OnEnable() {
        if (instance == null) {
            instance = this;
        }
        else {
            DestroyImmediate(this);
        }
    }


    public void StartLaunching() {
            
    }





}
