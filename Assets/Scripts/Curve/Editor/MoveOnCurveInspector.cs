using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Grenade))]
public class MoveOnCurveInspector :Editor {

    private Grenade moc;

    public override void OnInspectorGUI()
    {

        moc = target as Grenade;

        base.OnInspectorGUI();

        if (GUILayout.Button("Reset")) {
            moc.Reset();

        }
        

    }

}

