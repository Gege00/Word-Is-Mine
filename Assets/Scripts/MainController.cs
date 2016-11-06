using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

    void Update() {

        if (Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex==1) {
            SceneManager.LoadScene(0);

        }
    }


    public void StartGame() {

       
        SceneManager.LoadScene(1);
    }

}
