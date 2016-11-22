using System;
using UnityEngine;
using System.Collections;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public readonly int DEFAULTPOINT    = 100;
   




    [HideInInspector]
    public static GameController instance;

   
    public GrenadeLauncher[]  GrenadeLaunchers;
    public WordRequestManager WordRequestManager;
    public UIController UIController;
    public CameraController CameraController;
    public Slower Slower;
    public Text HealthText;
    public Text ScoreText;


    
    private Player player;
    private byte health;
    private uint waveCount;

    private GrenadeLauncher currentGrenadeLauncher;


    private uint _index;
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
        _index = 0;
        health = 6;
        HealthText.text = health.ToString();
        currentGrenadeLauncher = GrenadeLaunchers[_index];
        CameraController.SwitchCameraTo((int)_index);
        StartCoroutine(StartStage());

    }

    private IEnumerator StartStage() {
        yield return StartCoroutine(CountDown());
        waveCount = 0;
        while (health>0 && waveCount<currentGrenadeLauncher.stage.numberOfWaves  ) {
            //CheckDifficulty();
            Debug.Log(waveCount);
           StartLaunching();
           currentGrenadeLauncher.IsLaunching = true;
           yield return new WaitWhile(() => currentGrenadeLauncher.IsLaunching);
        }
        if (health == 0) {
           StartCoroutine(GameOver());
        }
        else {
            SwitchStage();

        }



    }

    private void SwitchStage() {
        _index++;
        currentGrenadeLauncher = GrenadeLaunchers[_index];
        CameraController.SwitchCameraTo((int)_index);
        if (_index < 4) {
            StartCoroutine(StartStage());
        }
    }

    private IEnumerator CountDown() {
        UIController.wordText.text = currentGrenadeLauncher.stage.stageName;
        yield return new WaitForSeconds(1f);
        int count = 3;
        UIController.wordText.text = count.ToString();
        while (count > 0) {
            yield return new WaitForSeconds(1f);
            count--;
            if (count == 0) {
                UIController.wordText.text = "GO!";
            }
            else {
                UIController.wordText.text = count.ToString();
            }
        }

    }


    private void SetSpeed() {
    //    GrenadeLauncher.launchSpeedMin = Difficulties[_actualGameRun.DiffLevel].LaunchSpeed;
    //    GrenadeLauncher.launchSpeedMax = Difficulties[_actualGameRun.DiffLevel].LaunchSpeed+0.2f;
    //    Slower.slowingValue = Difficulties[_actualGameRun.DiffLevel].SlowSpeed;
    }

    private IEnumerator GameOver() {
        UIController.wordText.text="GameOver";
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }

   

    public void StartLaunching() {

       // WordRequestManager.AddRequest(Difficulties[_actualGameRun.DiffLevel].WordLengthMin, Difficulties[_actualGameRun.DiffLevel].WordLengthMax,WordRequestCallback);
        WordRequestManager.AddRequest(currentGrenadeLauncher.stage.wordLengthMin, currentGrenadeLauncher.stage.worldLengthMax, WordRequestCallback);

    }

    public void WordRequestCallback(WordData wordData) {
        _actualWord = wordData;
        _actualIndex = 0;
        currentGrenadeLauncher.LaunchGrenades(wordData);
        waveCount++;

    }

    public void ShowWordOnGUI() {

        UIController.SetText(_actualWord.word);
    }

    public void WallHit() {
        health--;
        HealthText.text = health.ToString();
        currentGrenadeLauncher.ResetGrenades();
        UIController.Reset();
    }

    public void GetScore() {
       
        ScoreText.text += DEFAULTPOINT;
        UIController.Reset();
        currentGrenadeLauncher.ResetGrenades();

    }

    private void Miss() {
       

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
