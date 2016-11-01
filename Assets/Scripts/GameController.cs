using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public static GameController instance;

    [Range(3,6)]
    public int difficultyLevel=3;

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


    public void StartLaunching(int diffLevel=0) {
        if (diffLevel > 0) {
            difficultyLevel = diffLevel;
        }
        WordRequestManager.AddRequest(difficultyLevel, 0, GrenadeLauncher.LaunchGrenades);

    }





}
