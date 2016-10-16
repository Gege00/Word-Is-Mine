using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerInspector : Editor {

    private GameController gc;


    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        gc=target as GameController;
        if (GUILayout.Button("Launch")) {
            gc.StartLaunching();
        }
    }
}
