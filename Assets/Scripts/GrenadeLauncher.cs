using UnityEngine;
using System.Collections;




public class GrenadeLauncher : MonoBehaviour {


    public BezierSpline[] splines;
    public GameObject grenadePrefab;
    public float launchSpeedMin;
    public float launchSpeedMax;


    private static GrenadeLauncher instance;
    private readonly int numberOfsplines = 6;
    private Grenade[] _grenadeObjectPool;

    private UIController UIController;

    private string  _actualWord;
    public string ActualWord {
        get { return _actualWord;}
    }
    private int     _actualIndex        =0;

    private bool _launching = false;

    public bool IsLaunching {
        get {return _launching;}
        set { _launching = value; }
    }

    void OnEnable() {
        instance = this;
        UIController = GameObject.FindObjectOfType<UIController>();

    }

    public void LaunchGrenades(WordData wordData) {
        _launching = true;

        if (_grenadeObjectPool == null) {
            PopulatePool();
        }
        

     
        
        CharacterData[] charactersData = wordData.charsData;
        int worldLength =wordData.word.Length;
        int[] indicies = GetLauncherIndicies(worldLength);
        for (int i = 0; i < worldLength; i++) {
            _grenadeObjectPool[i].SetGrenade(splines[indicies[i]], Random.Range(launchSpeedMin, launchSpeedMax),charactersData[i]);
            _grenadeObjectPool[i].Launch();
        }
       
       
    }

    public void ResetGrenades() {
        
        foreach (var grenade in _grenadeObjectPool) {
            grenade.Reset();
        }

        _launching = false;
    }

    void PopulatePool() {
        int numberOfSplines = splines.Length;
        _grenadeObjectPool = new Grenade[numberOfSplines];
        for (int i = 0; i < numberOfSplines; i++) {
            GameObject grenadeObj = Instantiate(grenadePrefab);
            _grenadeObjectPool[i] = grenadeObj.GetComponent<Grenade>();
        }

    }




    private int[] GetLauncherIndicies(int wordLength) {
        switch (wordLength) {
            case 3:
                return new int[3] {0, 3, 5};
            case 4:
                return new int[4] {0, 2, 3, 5};
            case 5:
                return new int[5] {0, 1, 3, 4, 5};
            case 6:
                return new int[6] {0, 1, 2, 3, 4, 5};
        }
        return null;

    }
}
