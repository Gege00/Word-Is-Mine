using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [HideInInspector]
    public static GameController instance;

    [Range(3,6)]
    public int difficultyLevel=3;



    public GrenadeLauncher  GrenadeLauncher;
    public WordRequestManager WordRequestManager;
    public UIController UIController;


    private Player player;
    

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            DestroyImmediate(this);
        }
       // if (FindObjectOfType<MainController>().player == null) {
            player = new Player("test", DifficultyLevel.Easy, 3);
        //}
        //else {
        //    player = FindObjectOfType<MainController>().player;
        //}

    }




    public void StartLaunching(int diffLevel=0) {
        if (diffLevel > 0) {
            difficultyLevel = diffLevel;
        }
        WordRequestManager.AddRequest(difficultyLevel, 0, GrenadeLauncher.LaunchGrenades);

    }

    public void ShowWordOnGUI() {
        
        UIController.wordText.text = GrenadeLauncher.ActualWord;
    }

    public void WallHit() {
       player.DecreaseHealth();
       GrenadeLauncher.ResetGrenades();
       UIController.wordText.text = "";


    }







}
