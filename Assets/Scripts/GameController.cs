using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public readonly int DEFAULTPOINT    = 100;
   




    [HideInInspector]
    public static GameController instance;

    [Range(3,6)]
    public int difficultyLevel=3;

    public Difficulty[] Difficulties;
    public GrenadeLauncher  GrenadeLauncher;
    public WordRequestManager WordRequestManager;
    public UIController UIController;
    public Slower Slower;
    public Text HealthText;
    public Text ScoreText;


    
    private Player player;
    private byte health;

    private GameRun _actualGameRun;
    private int     _diffIndex;

    private WordData _actualWord;
    private int _actualIndex;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            DestroyImmediate(this);
        }
       if (!FindObjectOfType<MainController>()) {

            player = new Player();
        }
        else {
            player = FindObjectOfType<MainController>().player;
        }
       NewGame();

    }

    public void NewGame() {
        _actualGameRun = ScriptableObject.CreateInstance<GameRun>();
        health = 6;
        _diffIndex = 1;
        HealthText.text = health.ToString();
        SetSpeed();
        StartCoroutine(StartGame());

    }

    private IEnumerator StartGame() {

        while (health>0) {
            //CheckDifficulty();
           StartLaunching();
           GrenadeLauncher.IsLaunching = true;
           yield return new WaitWhile(()=>GrenadeLauncher.IsLaunching);
        }
        GameOver();
       
         
    }


    private void SetSpeed() {
        GrenadeLauncher.launchSpeedMin = Difficulties[_actualGameRun.DiffLevel].LaunchSpeed;
        GrenadeLauncher.launchSpeedMax = Difficulties[_actualGameRun.DiffLevel].LaunchSpeed+0.2f;
        Slower.slowingValue = Difficulties[_actualGameRun.DiffLevel].SlowSpeed;
    }

    private void GameOver() {

        StopCoroutine(StartGame());
        _actualGameRun.GameOver();


    }

    private void CheckDifficulty() {
        if (_actualGameRun.Streak > Difficulties[_diffIndex].StreakLimit*_actualIndex) {
            _diffIndex++;
            SetSpeed();
        }
    }




    public void StartLaunching() {

       // WordRequestManager.AddRequest(Difficulties[_actualGameRun.DiffLevel].WordLengthMin, Difficulties[_actualGameRun.DiffLevel].WordLengthMax,WordRequestCallback);
        WordRequestManager.AddRequest(3, 6,WordRequestCallback);

    }

    public void WordRequestCallback(WordData wordData) {
        _actualWord = wordData;
        _actualIndex = 0;
        GrenadeLauncher.LaunchGrenades(wordData);
    }

    public void ShowWordOnGUI() {

        UIController.SetText(_actualWord.word);
    }

    public void WallHit() {
        health--;
        HealthText.text = health.ToString();
        _actualGameRun.Streak = 0;
        GrenadeLauncher.ResetGrenades();
        UIController.Reset();
    }

    public void GetScore() {
        _actualGameRun.Streak++;
        ScoreText.text=_actualGameRun.IncreaseScore(DEFAULTPOINT).ToString();
        UIController.Reset();
        GrenadeLauncher.ResetGrenades();

    }

    private void Miss() {
        _actualGameRun.Streak = 0;

    }

    public static bool Validate(char c){
        if (instance._actualWord.word[instance._actualIndex] == c){
            if (instance._actualIndex + 1== instance._actualWord.word.Length) {
                instance.GetScore();
            }
            else
                instance._actualIndex++;

            return true;
        }
        else {
            instance.Miss();
            return false;
        }



    }







}
