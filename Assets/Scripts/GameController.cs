using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public static GameController instance;

    [Range(3,6)]
    public int difficultyLevel;

    public GrenadeLauncher  GrenadeLauncher;
    public WordRequestManager WordRequestManager;


    void OnEnable() {
        if (instance == null) {
            instance = this;
        }
        else {
            DestroyImmediate(this);
        }
    }


    public void StartLaunching() {
        WordRequestManager.AddRequest(difficultyLevel, 0, GrenadeLauncher.LaunchGrenades);

    }





}
