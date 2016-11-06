using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GrenadeLauncher))]
public class GrenadeLauncherInspector : Editor {

    private GrenadeLauncher gl;

    public void OnEnable() {
        gl=target as GrenadeLauncher;
    }

    public override void OnInspectorGUI() {
        
        DrawDefaultInspector();

        EditorGUILayout.MinMaxSlider( ref gl.launchSpeedMin, ref gl.launchSpeedMax,0.8f,3f);

        if (GUILayout.Button("Launch")) {
           // gl.LaunchGrenades();
        }
    }
}
