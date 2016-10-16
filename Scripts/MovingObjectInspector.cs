using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MovingObject))]
public class MovingObjectInspector : Editor {

   
    public override void OnInspectorGUI() {
        MovingObject obj= target as MovingObject;

        DrawDefaultInspector();

        if (GUILayout.Button("Moving")) {
            
            obj.Move();

        }
    }


}
